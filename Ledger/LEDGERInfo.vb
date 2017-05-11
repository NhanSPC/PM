
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

'Namespace PM

<Serializable()> _
Public Class LEDGERInfo
    Inherits Csla.ReadOnlyBase(Of LEDGERInfo)
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

    Private _reference As String = String.Empty
    Public ReadOnly Property Reference() As String
        Get
            Return _reference
        End Get
    End Property

    Private _transactionType As String = String.Empty
    Public ReadOnly Property TransactionType() As String
        Get
            Return _transactionType
        End Get
    End Property

    Private _transDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property TransDate() As String
        Get
            Return _transDate.DateViewFormat
        End Get
    End Property

    Private _period As SmartPeriod = New pbs.Helper.SmartPeriod()
    Public ReadOnly Property Period() As String
        Get
            Return _period.Text
        End Get
    End Property

    Private _customerCode As String = String.Empty
    Public ReadOnly Property CustomerCode() As String
        Get
            Return _customerCode
        End Get
    End Property

    Private _contractNo As String = String.Empty
    Public ReadOnly Property ContractNo() As String
        Get
            Return _contractNo
        End Get
    End Property

    Private _transAmt As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property TransAmt() As String
        Get
            Return _transAmt.Text
        End Get
    End Property

    Private _convCode As String = String.Empty
    Public ReadOnly Property ConvCode() As String
        Get
            Return _convCode
        End Get
    End Property

    Private _convRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property ConvRate() As String
        Get
            Return _convRate.Text
        End Get
    End Property

    Private _amount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property Amount() As String
        Get
            Return _amount.Text
        End Get
    End Property

    Private _dC As String = String.Empty
    Public ReadOnly Property DC() As String
        Get
            Return _dC
        End Get
    End Property

    Private _paymentRef As String = String.Empty
    Public ReadOnly Property PaymentRef() As String
        Get
            Return _paymentRef
        End Get
    End Property

    Private _payMethod As String = String.Empty
    Public ReadOnly Property PayMethod() As String
        Get
            Return _payMethod
        End Get
    End Property

    Private _paymentDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property PaymentDate() As String
        Get
            Return _paymentDate.DateViewFormat
        End Get
    End Property

    Private _paymentPeriod As SmartPeriod = New pbs.Helper.SmartPeriod()
    Public ReadOnly Property PaymentPeriod() As String
        Get
            Return _paymentPeriod.Text
        End Get
    End Property

    Private _invoiceNo As String = String.Empty
    Public ReadOnly Property InvoiceNo() As String
        Get
            Return _invoiceNo
        End Get
    End Property

    Private _invoiceSerial As String = String.Empty
    Public ReadOnly Property InvoiceSerial() As String
        Get
            Return _invoiceSerial
        End Get
    End Property

    Private _invoiceBook As String = String.Empty
    Public ReadOnly Property InvoiceBook() As String
        Get
            Return _invoiceBook
        End Get
    End Property

    Private _invoiceDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property InvoiceDate() As String
        Get
            Return _invoiceDate.DateViewFormat
        End Get
    End Property

    Private _invoicePeriod As SmartPeriod = New pbs.Helper.SmartPeriod()
    Public ReadOnly Property InvoicePeriod() As String
        Get
            Return _invoicePeriod.Text
        End Get
    End Property

    Private _ncPl0 As String = String.Empty
    Public ReadOnly Property NcPl0() As String
        Get
            Return _ncPl0
        End Get
    End Property

    Private _ncPl1 As String = String.Empty
    Public ReadOnly Property NcPl1() As String
        Get
            Return _ncPl1
        End Get
    End Property

    Private _ncPl2 As String = String.Empty
    Public ReadOnly Property NcPl2() As String
        Get
            Return _ncPl2
        End Get
    End Property

    Private _ncPl3 As String = String.Empty
    Public ReadOnly Property NcPl3() As String
        Get
            Return _ncPl3
        End Get
    End Property

    Private _ncPl4 As String = String.Empty
    Public ReadOnly Property NcPl4() As String
        Get
            Return _ncPl4
        End Get
    End Property

    Private _ncPl5 As String = String.Empty
    Public ReadOnly Property NcPl5() As String
        Get
            Return _ncPl5
        End Get
    End Property

    Private _ncPl6 As String = String.Empty
    Public ReadOnly Property NcPl6() As String
        Get
            Return _ncPl6
        End Get
    End Property

    Private _ncPl7 As String = String.Empty
    Public ReadOnly Property NcPl7() As String
        Get
            Return _ncPl7
        End Get
    End Property

    Private _ncPl8 As String = String.Empty
    Public ReadOnly Property NcPl8() As String
        Get
            Return _ncPl8
        End Get
    End Property

    Private _ncPl9 As String = String.Empty
    Public ReadOnly Property NcPl9() As String
        Get
            Return _ncPl9
        End Get
    End Property

    Private _allocation As String = String.Empty
    Public ReadOnly Property Allocation() As String
        Get
            Return _allocation
        End Get
    End Property

    Private _allocRef As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
    Public ReadOnly Property AllocRef() As String
        Get
            Return _allocRef.Text
        End Get
    End Property

    Private _allocDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property AllocDate() As String
        Get
            Return _allocDate.DateViewFormat
        End Get
    End Property

    Private _allocPeriod As SmartPeriod = New pbs.Helper.SmartPeriod()
    Public ReadOnly Property AllocPeriod() As String
        Get
            Return _allocPeriod.Text
        End Get
    End Property

    Private _status As String = String.Empty
    Public ReadOnly Property Status() As String
        Get
            Return _status
        End Get
    End Property

    Private _lockFlag As String = String.Empty
    Public ReadOnly Property LockFlag() As String
        Get
            Return _lockFlag
        End Get
    End Property

    Private _postingDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property PostingDate() As String
        Get
            Return _postingDate.DateViewFormat
        End Get
    End Property

    Private _postedBy As String = String.Empty
    Public ReadOnly Property PostedBy() As String
        Get
            Return _postedBy
        End Get
    End Property

    Private _holdOpId As String = String.Empty
    Public ReadOnly Property HoldOpId() As String
        Get
            Return _holdOpId
        End Get
    End Property

    Private _bphNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
    Public ReadOnly Property BphNo() As String
        Get
            Return _bphNo.Text
        End Get
    End Property

    Private _pfdNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
    Public ReadOnly Property PfdNo() As String
        Get
            Return _pfdNo.Text
        End Get
    End Property

    Private _extDesc1 As String = String.Empty
    Public ReadOnly Property ExtDesc1() As String
        Get
            Return _extDesc1
        End Get
    End Property

    Private _extDesc2 As String = String.Empty
    Public ReadOnly Property ExtDesc2() As String
        Get
            Return _extDesc2
        End Get
    End Property

    Private _extDesc3 As String = String.Empty
    Public ReadOnly Property ExtDesc3() As String
        Get
            Return _extDesc3
        End Get
    End Property

    Private _extDesc4 As String = String.Empty
    Public ReadOnly Property ExtDesc4() As String
        Get
            Return _extDesc4
        End Get
    End Property

    Private _extDesc5 As String = String.Empty
    Public ReadOnly Property ExtDesc5() As String
        Get
            Return _extDesc5
        End Get
    End Property

    Private _extDate1 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property ExtDate1() As String
        Get
            Return _extDate1.Text
        End Get
    End Property

    Private _extDate2 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property ExtDate2() As String
        Get
            Return _extDate2.Text
        End Get
    End Property

    Private _extDate3 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property ExtDate3() As String
        Get
            Return _extDate3.Text
        End Get
    End Property

    Private _extDate4 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property ExtDate4() As String
        Get
            Return _extDate4.Text
        End Get
    End Property

    Private _extDate5 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property ExtDate5() As String
        Get
            Return _extDate5.Text
        End Get
    End Property

    Private _extVal1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property ExtVal1() As String
        Get
            Return _extVal1.Text
        End Get
    End Property

    Private _extVal2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property ExtVal2() As String
        Get
            Return _extVal2.Text
        End Get
    End Property

    Private _extVal3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property ExtVal3() As String
        Get
            Return _extVal3.Text
        End Get
    End Property

    Private _extVal4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property ExtVal4() As String
        Get
            Return _extVal4.Text
        End Get
    End Property

    Private _extVal5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property ExtVal5() As String
        Get
            Return _extVal5.Text
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
            Return String.Format("Reference: {0}, Date: {1}", _reference, _transDate)
        End Get
    End Property


    Public Sub InvalidateCache() Implements IInfo.InvalidateCache
        LEDGERInfoList.InvalidateCache()
    End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

    Friend Shared Function GetLEDGERInfo(ByVal dr As SafeDataReader) As LEDGERInfo
        Return New LEDGERInfo(dr)
    End Function

    Friend Shared Function EmptyLEDGERInfo(Optional ByVal pLineNo As String = "") As LEDGERInfo
        Dim info As LEDGERInfo = New LEDGERInfo
        With info
            ._lineNo = pLineNo.ToInteger

        End With
        Return info
    End Function

    Private Sub New(ByVal dr As SafeDataReader)
        _lineNo = dr.GetInt32("LINE_NO")
        _reference = dr.GetString("REFERENCE").TrimEnd
        _transactionType = dr.GetString("TRANS_TYPE").TrimEnd
        _transDate.Text = dr.GetInt32("TRANS_DATE")
        _period.Text = dr.GetInt32("PERIOD")
        _customerCode = dr.GetString("CUSTOMER_CODE").TrimEnd
        _contractNo = dr.GetString("CONTRACT_NO").TrimEnd
        _transAmt.Text = dr.GetDecimal("TRANS_AMT")
        _convCode = dr.GetString("CONV_CODE").TrimEnd
        _convRate.Text = dr.GetDecimal("CONV_RATE")
        _amount.Text = dr.GetDecimal("AMOUNT")
        _dC = dr.GetString("D_C").TrimEnd
        _paymentRef = dr.GetString("PAYMENT_REF").TrimEnd
        _payMethod = dr.GetString("PAY_METHOD").TrimEnd
        _paymentDate.Text = dr.GetInt32("PAYMENT_DATE")
        _paymentPeriod.Text = dr.GetInt32("PAYMENT_PERIOD")
        _invoiceNo = dr.GetString("INVOICE_NO").TrimEnd
        _invoiceSerial = dr.GetString("INVOICE_SERIAL").TrimEnd
        _invoiceBook = dr.GetString("INVOICE_BOOK").TrimEnd
        _invoiceDate.Text = dr.GetInt32("INVOICE_DATE")
        _invoicePeriod.Text = dr.GetInt32("INVOICE_PERIOD")
        _ncPl0 = dr.GetString("NC_CN0").TrimEnd
        _ncPl1 = dr.GetString("NC_CN1").TrimEnd
        _ncPl2 = dr.GetString("NC_CN2").TrimEnd
        _ncPl3 = dr.GetString("NC_CN3").TrimEnd
        _ncPl4 = dr.GetString("NC_CN4").TrimEnd
        _ncPl5 = dr.GetString("NC_CN5").TrimEnd
        _ncPl6 = dr.GetString("NC_CN6").TrimEnd
        _ncPl7 = dr.GetString("NC_CN7").TrimEnd
        _ncPl8 = dr.GetString("NC_CN8").TrimEnd
        _ncPl9 = dr.GetString("NC_CN9").TrimEnd
        _allocation = dr.GetString("ALLOCATION").TrimEnd
        _allocRef.Text = dr.GetInt32("ALLOC_REF")
        _allocDate.Text = dr.GetInt32("ALLOC_DATE")
        _allocPeriod.Text = dr.GetInt32("ALLOC_PERIOD")
        _status = dr.GetString("STATUS").TrimEnd
        _lockFlag = dr.GetString("LOCK_FLAG").TrimEnd
        _postingDate.Text = dr.GetInt32("POSTING_DATE")
        _postedBy = dr.GetString("POSTED_BY").TrimEnd
        _holdOpId = dr.GetString("HOLD_OP_ID").TrimEnd
        _bphNo.Text = dr.GetInt32("BPH_NO")
        _pfdNo.Text = dr.GetInt32("PFD_NO")
        _extDesc1 = dr.GetString("EXT_DESC1").TrimEnd
        _extDesc2 = dr.GetString("EXT_DESC2").TrimEnd
        _extDesc3 = dr.GetString("EXT_DESC3").TrimEnd
        _extDesc4 = dr.GetString("EXT_DESC4").TrimEnd
        _extDesc5 = dr.GetString("EXT_DESC5").TrimEnd
        _extDate1.Text = dr.GetInt32("EXT_DATE1")
        _extDate2.Text = dr.GetInt32("EXT_DATE2")
        _extDate3.Text = dr.GetInt32("EXT_DATE3")
        _extDate4.Text = dr.GetInt32("EXT_DATE4")
        _extDate5.Text = dr.GetInt32("EXT_DATE5")
        _extVal1.Text = dr.GetDecimal("EXT_VAL1")
        _extVal2.Text = dr.GetDecimal("EXT_VAL2")
        _extVal3.Text = dr.GetDecimal("EXT_VAL3")
        _extVal4.Text = dr.GetDecimal("EXT_VAL4")
        _extVal5.Text = dr.GetDecimal("EXT_VAL5")

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