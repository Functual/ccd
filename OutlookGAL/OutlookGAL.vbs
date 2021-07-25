' File:		OutlookGAL.vbs
' Author:	Timur Kovalev (www.creativecodedesign.com)
' Purpose:	The script enumerates the Global Address List on a Microsoft Exchange Server and
'			creates a local copy of the address database in the file pointed to by 'OutputFileName'
'			variable.
CONST ServerName                            = "danversexch"
CONST UserName	                            = "timur.kovalev"					' i.e. first.last
CONST OutputFileName						= "C:\OutlookAddressBook.txt"		' where the data should go


CONST CdoPR_EMAIL							= &H39FE001E  'SMTP e-mail address 
CONST CdoPR_OFFICE_TELEPHONE_NUMBER         = &H3A08001E  'Business Phone
CONST CdoPR_COMPANY_NAME                    = &H3A16001E  'Company
CONST CdoPR_DEPARTMENT_NAME					= &H3A18001E  'Department 
CONST CdoPR_TITLE                           = &H3A17001E  'Title
CONST CdoPR_STREET_ADDRESS					= &H3A29001E  'Address 
CONST CdoPR_LOCALITY						= &H3A27001E  'City 
CONST CdoPR_STATE_OR_PROVINCE				= &H3A28001E  'State 
CONST CdoPR_POSTAL_CODE						= &H3A2A001E  'Zip code 
CONST CdoPR_BUSINESS_ADDRESS_COUNTRY		= &H3A26001E  'Country 
CONST CdoPR_MANAGER_NAME                    = &H3A4E001E  'Manager
CONST CdoPR_OFFICE2_TELEPHONE_NUMBER        = &H3A1B001E  'Business Phone 2
CONST CdoPR_BUSINESS_FAX_NUMBER             = &H3A24001E  'Fax
CONST CdoPR_MOBILE_TELEPHONE_NUMBER         = &H3A1C001E  'Mobile
CONST CdoPR_OFFICE_LOCATION                 = &H3A19001E  'Office


Dim objSession
Dim objSessions
Dim objAddrEntries
Dim objAddressEntry	
Dim objFilter
Dim strProfileInfo
Dim a, b, c

strProfileInfo = strServer & vbLf & strMailbox

Dim fso, f1
Set fso = CreateObject("Scripting.FileSystemObject")
Set f1 = fso.CreateTextFile(OutputFileName, True)									' Open the file where the data will be stored


set a = Wscript.CreateObject("Wscript.Shell")
Set objSession = CreateObject("Outlook.Application")
Set objSessions = CreateObject("MAPI.Session")										' 
Dim ResponseString

strProfileInfo = ServerName & vbLf & UserName
objSessions.Logon , , False, False, , True, strProfileInfo

Set objAddrEntries = objSessions.AddressLists("Global Address List").AddressEntries


On Error Resume Next	'Required, because, if an item like say, Manager Name, is missing, an 'error returns that stops the process.

For Each objAddressEntry In objAddrEntries
	ResponseString = ""
	ResponseString = objAddressEntry.Name
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_EMAIL).Value 
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_OFFICE_TELEPHONE_NUMBER).Value
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(cdoPR_COMPANY_NAME).Value
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_DEPARTMENT_NAME).Value
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_TITLE).Value
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_STREET_ADDRESS).Value
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_LOCALITY).Value
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_STATE_OR_PROVINCE).Value
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_POSTAL_CODE).Value 
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_BUSINESS_ADDRESS_COUNTRY).Value 
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_MANAGER_NAME).Value
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_OFFICE2_TELEPHONE_NUMBER).Value
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_BUSINESS_FAX_NUMBER).Value
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_MOBILE_TELEPHONE_NUMBER).Value
	ResponseString = ResponseString & Chr(9)
	ResponseString = ResponseString & objAddressEntry.Fields(CdoPR_OFFICE_LOCATION).Value

    f1.WriteLine(ResponseString) 
Next
f1.Close
objSessions.Logoff
MsgBox("Done!")

