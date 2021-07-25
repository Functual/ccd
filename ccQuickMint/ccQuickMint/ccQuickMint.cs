﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace cc.ccQuickMint
{
    /// <summary>
    /// Author: Timur Kovalev (http://creativecodedesign.com)
    /// This class provides basically functionality for reading a transaction CSV file
    /// exported from Mint and transforming it into an IIF format for importing into
    /// Quickbooks
    /// </summary>
    /// <remarks>going to ignore thread-safety for now.. parsing will happen single-threaded</remarks>
    public class ccQuickMint
    {
        string _lastError = string.Empty;
        static string _transactionFormat = "\"Date\",\"Description\",\"Original Description\",\"Amount\",\"Transaction Type\",\"Category\",\"Account Name\",\"Labels\",\"Notes\"";
        Dictionary<string, QuickMintAccount> _accountCollection = null;
        Dictionary<QuickMintAccount, List<QuickMintTransaction>> _accountTransactionCollection = null;
        public Dictionary<double, QuickMintTransaction> _storedTranferTransactions = null;
        uint _transactionIDCount = 0;
        public ccQuickMint()
        {
            _accountCollection = new Dictionary<string, QuickMintAccount>();
            _accountTransactionCollection = new Dictionary<QuickMintAccount, List<QuickMintTransaction>>();
            _storedTranferTransactions = new Dictionary<double, QuickMintTransaction>();
        }
        /// <summary>
        /// Attamts to laod and parse the CSV file generated by Mint's export transactions
        /// </summary>
        /// <param name="filePath">path to the file location</param>
        public bool LoadMintTransactions(string filePath)
        {
            try
            {
                string[] transactionLines = File.ReadAllLines(filePath);            // Read all file text split into lines
                if (transactionLines[0] != _transactionFormat)                      // if the format has changed
                {
                    _lastError = "Mint's CSV format appears to have changed or the header is missing. Will not continue due to data integrity concerns.";
                    return false;
                }
                for (int i = 1; i < transactionLines.Length; i++)
                {
                    string transactionLine = transactionLines[i];
                    if (transactionLine == ",,,,,,,,")
                        continue;
                    QuickMintTransaction transaction = new QuickMintTransaction(transactionLine, this);                 // create the transaction from cvs line
                    if (!_accountTransactionCollection.ContainsKey(transaction.Account))                                // check if we alread created an account associated with the transaction
                        _accountTransactionCollection.Add(transaction.Account, new List<QuickMintTransaction>());       // if not, add the account to out account transaction collaction
                    _accountTransactionCollection[transaction.Account].Add(transaction);                                // add the transaction to the account transaction collection
                }
            }
            catch (Exception ex)
            {
                _lastError = string.Format("Exception occured: {0} - {1}", ex.Message, ex.StackTrace);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Returns the last error if one exists (or empty string);
        /// </summary>
        /// <returns>last error</returns>
        public string GetLastError()
        {
            return _lastError;
        }
        /// <summary>
        /// returns the account object from the account collection. If the acocunt by this name
        /// is not yet preset, creates it. By default, account is created as bank. a ui can allow user to change this
        /// or other rules could be added
        /// </summary>
        /// <param name="accountName">the string representing the account name. Case Insensitive!</param>
        /// <param name="typeIfNew">the account type that shoudl be used, if this account is being created for the first time</param>
        /// <returns>QuickMintAccount corresponding to the specified name</returns>
        /// <remarks>static so it can easily be accessed by transaction instantiators. NOT THREAD SAFE!!</remarks>
        public QuickMintAccount GetQuickMintAccount(string accountName, QuickMintAccount.QuickMintAccountType typeIfNew)
        {            
            if(!_accountCollection.ContainsKey(accountName.ToLower()))
                _accountCollection.Add(accountName.ToLower(), new QuickMintAccount(accountName.ToLower(), typeIfNew, "No Descrition", ""));
            return _accountCollection[accountName.ToLower()];
        }
        /// <summary>
        /// Returns the list of transactions associated with the specified account
        /// </summary>
        /// <param name="sourceAccount">QuickMintAccount object represeting the account (use GetQuickMintAccount to get account by name)</param>
        /// <returns>List of transactions</returns>
        public List<QuickMintTransaction> GetQuickMintAccountTransactions(QuickMintAccount sourceAccount)
        {
            return _accountTransactionCollection[sourceAccount];
        }
        /// <summary>
        /// Returns the list of existing quickmint accounts
        /// </summary>
        public List<QuickMintAccount> TransactionAccounts
        {
            get 
            {
                return new List<QuickMintAccount>(_accountTransactionCollection.Keys);
            }
        }
        /// <summary>
        /// Returns current transaction counter and increments it
        /// </summary>
        /// <returns>current transaction counter</returns>
        public uint GetTransactionID()
        {
            uint retunVal = _transactionIDCount;
            _transactionIDCount ++;
            return retunVal;
        }
        /// <summary>
        /// Sets the transaction id to to specified value (used for IIF generation)
        /// </summary>
        /// <param name="id">transaction id that should be the start value</param>
        public void SetTransactionID(uint id)
        {
            _transactionIDCount = id;
        }
        /// <summary>
        /// Generates and returns a string in IIF format use to import all transactions associated with this instance
        /// </summary>
        /// <returns>IIF string</returns>
        public string GetTransactionIIF(bool ignoreTransfers)
        {
            StringBuilder returnText = new StringBuilder(QuickMintTransaction.GetIIFHeader());
            foreach (List<QuickMintTransaction> accountTransactions in _accountTransactionCollection.Values)
            {
                foreach (QuickMintTransaction currentTransaction in accountTransactions)
                    returnText.Append(currentTransaction.ToIIF(ignoreTransfers));
            }
            return returnText.ToString();
        }
        /// <summary>
        /// Generates and returns a string in IIF format to create transaction accounts for imported data
        /// </summary>
        /// <returns>IIF string</returns>
        public string GetAccountIIF()
        {
            StringBuilder returnText = new StringBuilder(QuickMintAccount.GetIIFHeader());
            foreach (QuickMintAccount currentTransaction in _accountCollection.Values)
                returnText.Append(currentTransaction.ToIIF());
            return returnText.ToString();
        }
    }
    /// <summary>
    /// This class represents an account object as understood by QuickBooks
    /// </summary>
    public class QuickMintAccount
    {
        /// <summary>
        /// Enumeration of supported Quickbooks account types. Since there are no asset or payable accounts,
        /// restricting this to Bank, Credit Card, Other Expense, Other Income, Income
        /// </summary>        
        public enum QuickMintAccountType { BANK, CCARD, EXP, EXINC, INC };
        /// <summary>
        /// Account Name
        /// </summary>
        /// <remarks>NAME</remarks>
        public string Name { get; set; }
        /// <summary>
        /// The type of account this is
        /// </summary>
        /// <remarks>ACCNTTYPE</remarks>
        public QuickMintAccountType Type { get; set; }
        /// <summary>
        /// Brief Descrition
        /// </summary>
        /// <remarks>DESC</remarks>
        public string Description { get; set; }
        /// <summary>
        /// The Number of this account
        /// </summary>
        /// <remarks>ACCNUM</remarks>
        public string Number { get; set; }
        public QuickMintAccount(string name, QuickMintAccountType type, string description, string number)
        {
            Name = name;
            Type = type;
            Description = description;
            Number = number;
        }
        public override string ToString()
        {
            return Name;
        }
        /// <summary>
        /// Returns the IIF header for a Quicbooks account
        /// </summary>
        /// <returns>IIF header for a Quicbooks account</returns>
        public static string GetIIFHeader()
        {
            return "!ACCNT\tNAME\tACCNTTYPE\tDESC\tACCNUM\tEXTRA\r\n";
        }
        /// <summary>
        /// Returns IIF string representing this account
        /// </summary>
        /// <returns>IIF string representing this account</returns>
        public string ToIIF()
        {
            return string.Format("ACCNT\t{0}\t{1}\t{2}\t{3}\t\r\n", Name, Type, Description, Number);
        }
    }
    /// <summary>
    /// This object represents a mint transaction. It models the headers of Mint's CSV export
    /// </summary>
    public class QuickMintTransaction
    {
        /// <summary>
        /// Transaction date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Transaction description as it appears now in mint
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The original description as it appared after being downloaded into mint (before user change)
        /// </summary>
        public string OriginalDescription { get; set; }
        /// <summary>
        /// Transaction amount (note: this will always be positive and relation to account is determined by the transaction type)
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// The type of the transaction relative to transaction account (Debit or Credit)
        /// </summary>
        public QuickMintTransactionType Type { get; set; }
        /// <summary>
        /// Represents the Mint category the transaction was entered into. These will be used as the SPLIT account in quickbooks
        /// Thus, These really represent expense or income accounts (Mint has no receivables or payables.. sweet!)
        /// </summary>
        public QuickMintAccount Category { get; set; }
        /// <summary>
        /// The name of the account where the transaction appears
        /// </summary>
        public QuickMintAccount Account { get; set; }
        /// <summary>
        /// Transaction Label
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Notes, if any, associated with the transaction
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Holds the instance of the account this transaction belongs to
        /// </summary>
        private ccQuickMint _parentInstance = null;         
        /// <summary>
        /// Instantiates a quickmint transaction using the line from exported CSV. Line is expected in format
        /// Date,Description,Original Description,Amount,Transaction Type,Category,Account Name,Labels,Notes
        /// </summary>
        /// <param name="transactionLine">the line from the csv matchin _transactionFormat</param>
        /// <remarks>Date,Description,Original Description,Amount,Transaction Type,Category,Account Name,Labels,Notes</remarks>
        public QuickMintTransaction(string transactionLine, ccQuickMint parentInstance)
        {
            _parentInstance = parentInstance;
            transactionLine = NormalizeTransactionLine(transactionLine);
            string[] transactionItems = transactionLine.Split(new char[] { ',' });            
            try
            {
                Date = DateTime.Parse(transactionItems[0]);
                Description = transactionItems[1];
                OriginalDescription = transactionItems[2];
                Amount = Convert.ToDouble(transactionItems[3]);
                Type = (transactionItems[4].ToLower() == "debit") ? QuickMintTransactionType.Debit : QuickMintTransactionType.Credit;
                if (transactionItems[5].Contains("Income"))
                    Category = parentInstance.GetQuickMintAccount(transactionItems[5], QuickMintAccount.QuickMintAccountType.INC);      // by default, this will be expense
                else
                    Category = parentInstance.GetQuickMintAccount(transactionItems[5], QuickMintAccount.QuickMintAccountType.EXP);      // by default, this will be expense
                Account = parentInstance.GetQuickMintAccount(transactionItems[6], QuickMintAccount.QuickMintAccountType.BANK);          // by default, this will be a bank
                Label = transactionItems[7];
                Notes = transactionItems[8];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Removes special characters from the transaction line that violate formats
        /// These include quotes, commas (in the description), tabs
        /// </summary>
        /// <param name="transactionLine">the transaction line as read from Mint's CSV</param>
        /// <returns>a transaction line without special characters</returns>
        private static string NormalizeTransactionLine(string transactionLine)
        {
            string normalizedTransactionLine = transactionLine;
            if (transactionLine.Contains('\"'))                             // if there are quotes, it means there are funcky chars in the description
            {                                                               // like commas and tabs
                Regex descritionRegex = new Regex("(\")(.*?)(\")");         // match everything between quotes
                MatchCollection matches = descritionRegex.Matches(transactionLine);
                foreach (Match currentMatch in matches)
                {
                    string replacement = currentMatch.Groups[2].Value.Replace(',', ' ').Replace('\t', ' '); // strip commas and tabs
                    normalizedTransactionLine = normalizedTransactionLine.Replace(currentMatch.Groups[0].Value, replacement);   // fix transaction line
                }
            }
            return normalizedTransactionLine;
        }
        public static string GetIIFHeader()
        {
            return "!TRNS\tTRNSID\tTRNSTYPE\tDATE\tACCNT\tNAME\tCLASS\tAMOUNT\tDOCNUM\r\n!SPL\tSPLID\tTRNSTYPE\tDATE\tACCNT\tNAME\tCLASS\tAMOUNT\tDOCNUM\r\n!ENDTRNS\r\n";
        }
        /// <summary>
        /// Converts current transaction instance to IIF format include the transaction and associated SPL if any
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        /// <remarks>types: CHECK, CREDIT CARD, DEPOSIT</remarks>
        public string ToIIF(bool ignoreTransfers)
        {
            if (ignoreTransfers && Category.ToString() == "credit card payment")                        // ignore card payment transactions on both sides
                return "";
            else if (Category.ToString() == "credit card payment" || Category.ToString() == "transfer") // if credit card payment or transfer
            {
                if (_parentInstance._storedTranferTransactions.ContainsKey(Amount))                     // we have the corresponding transaction stored
                {                    
                    string returnValue = ToIIF(_parentInstance._storedTranferTransactions[Amount]);
                    _parentInstance._storedTranferTransactions.Remove(Amount);                          // remove the transaction
                    return returnValue;
                }
                else
                {
                    _parentInstance._storedTranferTransactions.Add(Amount, this);
                    return "";
                }
            }
            string qbTransactionType = (Account.Type==QuickMintAccount.QuickMintAccountType.BANK) ? "CHECK" : "CREDIT CARD";
            qbTransactionType = (Type == QuickMintTransactionType.Debit) ? qbTransactionType : "DEPOSIT";                       // if this is a credit to transaction account, treat it as deposit
            qbTransactionType = (Type == QuickMintTransactionType.Credit && Account.Type == QuickMintAccount.QuickMintAccountType.CCARD) ? "CCARD REFUND" : qbTransactionType;
            double amount = (Type == QuickMintTransactionType.Credit) ? Amount : Amount * -1;
            string transactionIIF = string.Format("TRNS\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\r\n", 
                _parentInstance.GetTransactionID(), qbTransactionType, Date.ToShortDateString(), Account, Description, "", amount, "");
            string splitIIF = string.Format("SPL\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\r\nENDTRNS\r\n",
                _parentInstance.GetTransactionID(), qbTransactionType, Date.ToShortDateString(), Category, "", "", amount * -1, "");
            return string.Concat(transactionIIF, splitIIF);
        }
        /// <summary>
        /// Records a transfer transaction given the transaction of another account that is the counter to the 
        /// transaction associated with the current instance
        /// </summary>
        /// <param name="counterTransaction">transaction for another account that </param>
        /// <returns>string representing IIF notation necessary to </returns>
        private string ToIIF(QuickMintTransaction counterTransaction)
        {
            double amount = (Type == QuickMintTransactionType.Credit) ? Amount : Amount * -1;                       // debits are negative, credits are positive - CPA now!
            string transactionIIF = string.Format("TRNS\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\r\n",            
                _parentInstance.GetTransactionID(), "TRANSFER", Date.ToShortDateString(), Account, Description, "", amount, "");
            string counterTransactionIIF = string.Format("SPL\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\r\nENDTRNS\r\n",
                _parentInstance.GetTransactionID(), "TRANSFER", Date.ToShortDateString(), counterTransaction.Account, counterTransaction.Description, 
                "", amount * -1, "");
            return string.Concat(transactionIIF, counterTransactionIIF);
        }
    }
    /// <summary>
    /// Type of transactions available
    /// </summary>
    public enum QuickMintTransactionType { Debit, Credit }    
}