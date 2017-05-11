
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

'Namespace PM

<Serializable()> _
Public Class CTRInfo
    Inherits Csla.ReadOnlyBase(Of CTRInfo)
    Implements IComparable
    Implements IInfo
    Implements IDocLink
    'Implements IInfoStatus


#Region " Business Properties and Methods "


    Private _lineNo As Integer
    Public ReadOnly Property LineNo() As Integer
        Get
            Return _lineNo
        End Get
    End Property

    Private _contractNo As String = String.Empty
    Public ReadOnly Property ContractNo() As String
        Get
            Return _contractNo
        End Get
    End Property

    Private _contractDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property ContractDate() As String
        Get
            Return _contractDate.DateViewFormat
        End Get
    End Property

    Private _contractor As String = String.Empty
    Public ReadOnly Property Contractor() As String
        Get
            Return _contractor
        End Get
    End Property

    Private _contructionUnit As String = String.Empty
    Public ReadOnly Property ContructionUnit() As String
        Get
            Return _contructionUnit
        End Get
    End Property

    Private _contructionUnitName As String = String.Empty
    Public ReadOnly Property ContructionUnitName() As String
        Get
            Return _contructionUnitName
        End Get
    End Property

    Private _contractType As String = String.Empty
    Public ReadOnly Property ContractType() As String
        Get
            Return _contractType
        End Get
    End Property

    Private _contractForm As String = String.Empty
    Public ReadOnly Property ContractForm() As String
        Get
            Return _contractForm
        End Get
    End Property

    Private _currency As String = String.Empty
    Public ReadOnly Property Currency() As String
        Get
            Return _currency
        End Get
    End Property

    Private _contractValue As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property ContractValue() As String
        Get
            Return _contractValue.Text
        End Get
    End Property

    Private _vatRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property VatRate() As String
        Get
            Return _vatRate.Text
        End Get
    End Property

    Private _vatAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property VatAmount() As String
        Get
            Return _vatAmount.Text
        End Get
    End Property

    Private _retentionRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property RetentionRate() As String
        Get
            Return _retentionRate.Text
        End Get
    End Property

    Private _retentionAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property RetentionAmount() As String
        Get
            Return _retentionAmount.Text
        End Get
    End Property

    Private _projectCode As String = String.Empty
    Public ReadOnly Property ProjectCode() As String
        Get
            Return _projectCode
        End Get
    End Property

    Private _performanceSecurityRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property PerformanceSecurityRate() As String
        Get
            Return _performanceSecurityRate.Text
        End Get
    End Property

    Private _performanceSecurityAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property PerformanceSecurityAmount() As String
        Get
            Return _performanceSecurityAmount.Text
        End Get
    End Property

    Private _validTo As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property ValidTo() As String
        Get
            Return _validTo.DateViewFormat
        End Get
    End Property

    Private _performFrom As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property PerformFrom() As String
        Get
            Return _performFrom.DateViewFormat
        End Get
    End Property

    Private _performTo As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property PerformTo() As String
        Get
            Return _performTo.DateViewFormat
        End Get
    End Property

    Private _contractContents As String = String.Empty
    Public ReadOnly Property ContractContents() As String
        Get
            Return _contractContents
        End Get
    End Property

    Private _processingRequest As String = String.Empty
    Public ReadOnly Property ProcessingRequest() As String
        Get
            Return _processingRequest
        End Get
    End Property

    Private _paymentTerms As String = String.Empty
    Public ReadOnly Property PaymentTerms() As String
        Get
            Return _paymentTerms
        End Get
    End Property

    Private _comments As String = String.Empty
    Public ReadOnly Property Comments() As String
        Get
            Return _comments
        End Get
    End Property

    Private _appendix As String = String.Empty
    Public ReadOnly Property Appendix() As String
        Get
            Return _appendix
        End Get
    End Property

    Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property Updated() As String
        Get
            Return _updated.DateViewFormat
        End Get
    End Property

    Private _updatedBy As String = String.Empty
    Public ReadOnly Property UpdatedBy() As String
        Get
            Return _updatedBy
        End Get
    End Property

    'Get ID
    Protected Overrides Function GetIdValue() As Object
        Return _lineNo
    End Function

    'IComparable
    Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
        Dim ID = IDObject.ToString
        Dim pLineNo As Integer = ID.Trim.ToInteger
        If _lineNo < pLineNo Then Return -1
        If _lineNo > pLineNo Then Return 1
        Return 0
    End Function

    Public ReadOnly Property Code As String Implements IInfo.Code
        Get
            Return _lineNo
        End Get
    End Property

    Public ReadOnly Property LookUp As String Implements IInfo.LookUp
        Get
            Return _lineNo
        End Get
    End Property

    Public ReadOnly Property Description As String Implements IInfo.Description
        Get
            Return String.Format("Contract number: {0}, Date: {1}", _contractNo, _contractDate)
        End Get
    End Property


    Public Sub InvalidateCache() Implements IInfo.InvalidateCache
        CTRInfoList.InvalidateCache()
    End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

    Friend Shared Function GetCTRInfo(ByVal dr As SafeDataReader) As CTRInfo
        Return New CTRInfo(dr)
    End Function

    Friend Shared Function EmptyCTRInfo(Optional ByVal pLineNo As String = "") As CTRInfo
        Dim info As CTRInfo = New CTRInfo
        With info
            ._lineNo = pLineNo.ToInteger

        End With
        Return info
    End Function

    Private Sub New(ByVal dr As SafeDataReader)
        _lineNo = dr.GetInt32("LINE_NO")
        _contractNo = dr.GetString("CONTRACT_NO").TrimEnd
        _contractDate.Text = dr.GetInt32("CONTRACT_DATE")
        _contractor = dr.GetString("CONTRACTOR").TrimEnd
        _contructionUnit = dr.GetString("CONSTRUCTION_UNIT").TrimEnd
        _contructionUnitName = dr.GetString("CONSTRUCTION_UNIT_NAME").TrimEnd
        _contractType = dr.GetString("CONTRACT_TYPE").TrimEnd
        _contractForm = dr.GetString("CONTRACT_FORM").TrimEnd
        _currency = dr.GetString("CURRENCY").TrimEnd
        _contractValue.Text = dr.GetDecimal("CONTRACT_VALUE")
        _vatRate.Text = dr.GetDecimal("VAT_RATE")
        _vatAmount.Text = dr.GetDecimal("VAT_AMOUNT")
        _retentionRate.Text = dr.GetDecimal("RETENTION_RATE")
        _retentionAmount.Text = dr.GetDecimal("RETENTION_AMOUNT")
        _projectCode = dr.GetString("PROJECT_CODE").TrimEnd
        _performanceSecurityRate.Text = dr.GetDecimal("PERFORMANCE_SECURITY_RATE")
        _performanceSecurityAmount.Text = dr.GetDecimal("PERFORMANCE_SECURITY_AMOUNT")
        _validTo.Text = dr.GetInt32("VALID_TO")
        _performFrom.Text = dr.GetInt32("PERFORM_FROM")
        _performTo.Text = dr.GetInt32("PERFORM_TO")
        _contractContents = dr.GetString("CONTRACT_CONTENTS").TrimEnd
        _processingRequest = dr.GetString("PROCESSING_REQUEST").TrimEnd
        _paymentTerms = dr.GetString("PAYMENT_TERMS").TrimEnd
        _comments = dr.GetString("COMMENTS").TrimEnd
        _appendix = dr.GetString("APPENDIX").TrimEnd
        _updated.Text = dr.GetInt32("UPDATED")
        _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

    End Sub

    Private Sub New()
    End Sub


#End Region ' Factory Methods

#Region "IDoclink"
    Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
        Return String.Format("{0}#{1}", Get_TransType, _lineNo)
    End Function

    Public Function Get_TransType() As String Implements IDocLink.Get_TransType
        Return Me.GetType.ToClassSchemaName.Leaf
    End Function
#End Region

End Class

'End Namespace