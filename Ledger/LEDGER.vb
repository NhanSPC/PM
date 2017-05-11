Imports pbs.Helper
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports pbs.BO.DataAnnotations
Imports pbs.BO.Script
Imports pbs.BO.BusinessRules


'Namespace PM

<Serializable()> _
<DB(TableName:="pbs_PM_LEDGER_{XXX}")>
Public Class LEDGER
    Inherits Csla.BusinessBase(Of LEDGER)
    Implements Interfaces.IGenPartObject
    Implements IComparable
    Implements IDocLink



#Region "Property Changed"
    Protected Overrides Sub OnDeserialized(context As Runtime.Serialization.StreamingContext)
        MyBase.OnDeserialized(context)
        AddHandler Me.PropertyChanged, AddressOf BO_PropertyChanged
    End Sub

    Private Sub BO_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles Me.PropertyChanged
        Select Case e.PropertyName

            Case "TransDate"
                _period.Text = _transDate.Date.Month

            Case "PaymentDate"
                _paymentPeriod.Text = _paymentDate.Date.Month

            Case "InvoiceDate"
                _invoicePeriod.Text = _invoiceDate.Date.Month

            Case "AllocDate"
                _allocPeriod.Text = _allocDate.Date.Month

                '    Case "OrderType"
                '        If Not Me.GetOrderTypeInfo.ManualRef Then
                '            Me._orderNo = POH.AutoReference
                '        End If

                '    Case "OrderDate"
                '        If String.IsNullOrEmpty(Me.OrderPrd) Then Me._orderPrd.Text = Me._orderDate.Date.ToSunPeriod

                '    Case "SuppCode"
                '        For Each line In Lines
                '            line._suppCode = Me.SuppCode
                '        Next

                '    Case "ConvCode"
                '        If String.IsNullOrEmpty(Me.ConvCode) Then
                '            _convRate.Float = 0
                '        Else
                '            Dim conv = pbs.BO.LA.CVInfoList.GetConverter(Me.ConvCode, _orderPrd, String.Empty)
                '            If conv IsNot Nothing Then
                '                _convRate.Float = conv.DefaultRate
                '            End If
                '        End If

                '    Case Else

        End Select

        pbs.BO.Rules.CalculationRules.Calculator(sender, e)
    End Sub
#End Region

#Region " Business Properties and Methods "
    Private _DTB As String = String.Empty


    Private _lineNo As Integer
    <System.ComponentModel.DataObjectField(True, True)> _
    <CellInfo(Hidden:=True)>
    Public ReadOnly Property LineNo() As String
        Get
            Return _lineNo
        End Get
    End Property

    Private _reference As String = String.Empty
    <CellInfo(GroupName:="Transaction", Tips:="Enter reference number")>
    <Rule(Required:=True)>
    Public Property Reference() As String
        Get
            Return _reference
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Reference", True)
            If value Is Nothing Then value = String.Empty
            If Not _reference.Equals(value) Then
                _reference = value
                PropertyHasChanged("Reference")
            End If
        End Set
    End Property

    Private _transactionType As String = String.Empty
    <CellInfo(GroupName:="Transaction", Tips:="Enter transaction type")>
    Public Property TransactionType() As String
        Get
            Return _transactionType
        End Get
        Set(ByVal value As String)
            CanWriteProperty("TransactionType", True)
            If value Is Nothing Then value = String.Empty
            If Not _transactionType.Equals(value) Then
                _transactionType = value
                PropertyHasChanged("TransactionType")
            End If
        End Set
    End Property

    Private _transDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(LinkCode.Calendar, GroupName:="Transaction", Tips:="Enter transaction date")>
    <Rule(Required:=True)>
    Public Property TransDate() As String
        Get
            Return _transDate.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("TransDate", True)
            If value Is Nothing Then value = String.Empty
            If Not _transDate.Equals(value) Then
                _transDate.Text = value
                PropertyHasChanged("TransDate")
            End If
        End Set
    End Property

    Private _period As SmartPeriod = New pbs.Helper.SmartPeriod()
    <CellInfo(GroupName:="Transaction", Tips:="Enter transaction period")>
    Public Property Period() As String
        Get
            Return _period.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Period", True)
            If value Is Nothing Then value = String.Empty
            If Not _period.Equals(value) Then
                _period.Text = value
                PropertyHasChanged("Period")
            End If
        End Set
    End Property

    Private _customerCode As String = String.Empty
    <CellInfo(GroupName:="Transaction", Tips:="Enter Customer code")>
    Public Property CustomerCode() As String
        Get
            Return _customerCode
        End Get
        Set(ByVal value As String)
            CanWriteProperty("CustomerCode", True)
            If value Is Nothing Then value = String.Empty
            If Not _customerCode.Equals(value) Then
                _customerCode = value
                PropertyHasChanged("CustomerCode")
            End If
        End Set
    End Property

    Private _contractNo As String = String.Empty
    <CellInfo("pbs.BO.PM.CTR", GroupName:="Transaction", Tips:="Enter contract number")>
    Public Property ContractNo() As String
        Get
            Return _contractNo
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ContractNo", True)
            If value Is Nothing Then value = String.Empty
            If Not _contractNo.Equals(value) Then
                _contractNo = value
                PropertyHasChanged("ContractNo")
            End If
        End Set
    End Property

    Private _transAmt As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(GroupName:="Transaction", Tips:="Enter transaction amount")>
    Public Property TransAmt() As String
        Get
            Return _transAmt.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("TransAmt", True)
            If value Is Nothing Then value = String.Empty
            If Not _transAmt.Equals(value) Then
                _transAmt.Text = value
                PropertyHasChanged("TransAmt")
            End If
        End Set
    End Property

    Private _convCode As String = String.Empty
    <CellInfo(GroupName:="Transaction", Tips:="Conversion code")>
    Public Property ConvCode() As String
        Get
            Return _convCode
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ConvCode", True)
            If value Is Nothing Then value = String.Empty
            If Not _convCode.Equals(value) Then
                _convCode = value
                PropertyHasChanged("ConvCode")
            End If
        End Set
    End Property

    Private _convRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(GroupName:="Transaction", Tips:="Enter conversion rate")>
    Public Property ConvRate() As String
        Get
            Return _convRate.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ConvRate", True)
            If value Is Nothing Then value = String.Empty
            If Not _convRate.Equals(value) Then
                _convRate.Text = value
                PropertyHasChanged("ConvRate")
            End If
        End Set
    End Property

    Private _amount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(GroupName:="Transaction", Tips:="Enter amount")>
    Public Property Amount() As String
        Get
            Return _amount.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Amount", True)
            If value Is Nothing Then value = String.Empty
            If Not _amount.Equals(value) Then
                _amount.Text = value
                PropertyHasChanged("Amount")
            End If
        End Set
    End Property

    Private _dC As String = String.Empty
    <CellInfo(GroupName:="Transaction", Tips:="Enter type of transaction. D: debit, C: credit")>
    Public Property DC() As String
        Get
            Return _dC
        End Get
        Set(ByVal value As String)
            CanWriteProperty("DC", True)
            If value Is Nothing Then value = String.Empty
            If Not _dC.Equals(value) Then
                _dC = value
                PropertyHasChanged("DC")
            End If
        End Set
    End Property

    Private _paymentRef As String = String.Empty
    <CellInfo(GroupName:="Payment", Tips:="Enter payment reference")>
    Public Property PaymentRef() As String
        Get
            Return _paymentRef
        End Get
        Set(ByVal value As String)
            CanWriteProperty("PaymentRef", True)
            If value Is Nothing Then value = String.Empty
            If Not _paymentRef.Equals(value) Then
                _paymentRef = value
                PropertyHasChanged("PaymentRef")
            End If
        End Set
    End Property

    Private _payMethod As String = String.Empty
    <CellInfo(GroupName:="Payment", Tips:="Enter payment method")>
    Public Property PayMethod() As String
        Get
            Return _payMethod
        End Get
        Set(ByVal value As String)
            CanWriteProperty("PayMethod", True)
            If value Is Nothing Then value = String.Empty
            If Not _payMethod.Equals(value) Then
                _payMethod = value
                PropertyHasChanged("PayMethod")
            End If
        End Set
    End Property

    Private _paymentDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(LinkCode.Calendar, GroupName:="Payment", Tips:="Enter payment date")>
    Public Property PaymentDate() As String
        Get
            Return _paymentDate.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("PaymentDate", True)
            If value Is Nothing Then value = String.Empty
            If Not _paymentDate.Equals(value) Then
                _paymentDate.Text = value
                PropertyHasChanged("PaymentDate")
            End If
        End Set
    End Property

    Private _paymentPeriod As SmartPeriod = New pbs.Helper.SmartPeriod()
    <CellInfo(GroupName:="Payment", Tips:="Enter payment period")>
    Public Property PaymentPeriod() As String
        Get
            Return _paymentPeriod.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("PaymentPeriod", True)
            If value Is Nothing Then value = String.Empty
            If Not _paymentPeriod.Equals(value) Then
                _paymentPeriod.Text = value
                PropertyHasChanged("PaymentPeriod")
            End If
        End Set
    End Property

    Private _invoiceNo As String = String.Empty
    <CellInfo(GroupName:="Invoice", Tips:="Enter invoice number")>
    Public Property InvoiceNo() As String
        Get
            Return _invoiceNo
        End Get
        Set(ByVal value As String)
            CanWriteProperty("InvoiceNo", True)
            If value Is Nothing Then value = String.Empty
            If Not _invoiceNo.Equals(value) Then
                _invoiceNo = value
                PropertyHasChanged("InvoiceNo")
            End If
        End Set
    End Property

    Private _invoiceSerial As String = String.Empty
    <CellInfo(GroupName:="Invoice", Tips:="Enter invoice serial")>
    Public Property InvoiceSerial() As String
        Get
            Return _invoiceSerial
        End Get
        Set(ByVal value As String)
            CanWriteProperty("InvoiceSerial", True)
            If value Is Nothing Then value = String.Empty
            If Not _invoiceSerial.Equals(value) Then
                _invoiceSerial = value
                PropertyHasChanged("InvoiceSerial")
            End If
        End Set
    End Property

    Private _invoiceBook As String = String.Empty
    <CellInfo(GroupName:="Invoice", Tips:="Enter invoice book")>
    Public Property InvoiceBook() As String
        Get
            Return _invoiceBook
        End Get
        Set(ByVal value As String)
            CanWriteProperty("InvoiceBook", True)
            If value Is Nothing Then value = String.Empty
            If Not _invoiceBook.Equals(value) Then
                _invoiceBook = value
                PropertyHasChanged("InvoiceBook")
            End If
        End Set
    End Property

    Private _invoiceDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(LinkCode.Calendar, GroupName:="Invoice", Tips:="Enter invoice date")>
    Public Property InvoiceDate() As String
        Get
            Return _invoiceDate.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("InvoiceDate", True)
            If value Is Nothing Then value = String.Empty
            If Not _invoiceDate.Equals(value) Then
                _invoiceDate.Text = value
                PropertyHasChanged("InvoiceDate")
            End If
        End Set
    End Property

    Private _invoicePeriod As SmartPeriod = New pbs.Helper.SmartPeriod()
    <CellInfo(GroupName:="Invoice", Tips:="Enter invoice period")>
    Public Property InvoicePeriod() As String
        Get
            Return _invoicePeriod.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("InvoicePeriod", True)
            If value Is Nothing Then value = String.Empty
            If Not _invoicePeriod.Equals(value) Then
                _invoicePeriod.Text = value
                PropertyHasChanged("InvoicePeriod")
            End If
        End Set
    End Property

    Private _ncCn0 As String = String.Empty
    <CellInfo(GroupName:="Analysis")>
    Public Property NcCn0() As String
        Get
            Return _ncCn0
        End Get
        Set(ByVal value As String)
            CanWriteProperty("NcCn0", True)
            If value Is Nothing Then value = String.Empty
            If Not _ncCn0.Equals(value) Then
                _ncCn0 = value
                PropertyHasChanged("NcCn0")
            End If
        End Set
    End Property

    Private _ncCn1 As String = String.Empty
    <CellInfo(GroupName:="Analysis")>
    Public Property NcCn1() As String
        Get
            Return _ncCn1
        End Get
        Set(ByVal value As String)
            CanWriteProperty("NcCn1", True)
            If value Is Nothing Then value = String.Empty
            If Not _ncCn1.Equals(value) Then
                _ncCn1 = value
                PropertyHasChanged("NcCn1")
            End If
        End Set
    End Property

    Private _ncCn2 As String = String.Empty
    <CellInfo(GroupName:="Analysis")>
    Public Property NcCn2() As String
        Get
            Return _ncCn2
        End Get
        Set(ByVal value As String)
            CanWriteProperty("NcCn2", True)
            If value Is Nothing Then value = String.Empty
            If Not _ncCn2.Equals(value) Then
                _ncCn2 = value
                PropertyHasChanged("NcCn2")
            End If
        End Set
    End Property

    Private _ncCn3 As String = String.Empty
    <CellInfo(GroupName:="Analysis")>
    Public Property NcCn3() As String
        Get
            Return _ncCn3
        End Get
        Set(ByVal value As String)
            CanWriteProperty("NcCn3", True)
            If value Is Nothing Then value = String.Empty
            If Not _ncCn3.Equals(value) Then
                _ncCn3 = value
                PropertyHasChanged("NcCn3")
            End If
        End Set
    End Property

    Private _ncCn4 As String = String.Empty
    <CellInfo(GroupName:="Analysis")>
    Public Property NcCn4() As String
        Get
            Return _ncCn4
        End Get
        Set(ByVal value As String)
            CanWriteProperty("NcCn4", True)
            If value Is Nothing Then value = String.Empty
            If Not _ncCn4.Equals(value) Then
                _ncCn4 = value
                PropertyHasChanged("NcCn4")
            End If
        End Set
    End Property

    Private _ncCn5 As String = String.Empty
    <CellInfo(GroupName:="Analysis")>
    Public Property NcCn5() As String
        Get
            Return _ncCn5
        End Get
        Set(ByVal value As String)
            CanWriteProperty("NcCn5", True)
            If value Is Nothing Then value = String.Empty
            If Not _ncCn5.Equals(value) Then
                _ncCn5 = value
                PropertyHasChanged("NcCn5")
            End If
        End Set
    End Property

    Private _ncCn6 As String = String.Empty
    <CellInfo(GroupName:="Analysis")>
    Public Property NcCn6() As String
        Get
            Return _ncCn6
        End Get
        Set(ByVal value As String)
            CanWriteProperty("NcCn6", True)
            If value Is Nothing Then value = String.Empty
            If Not _ncCn6.Equals(value) Then
                _ncCn6 = value
                PropertyHasChanged("NcCn6")
            End If
        End Set
    End Property

    Private _ncCn7 As String = String.Empty
    <CellInfo(GroupName:="Analysis")>
    Public Property NcCn7() As String
        Get
            Return _ncCn7
        End Get
        Set(ByVal value As String)
            CanWriteProperty("NcCn7", True)
            If value Is Nothing Then value = String.Empty
            If Not _ncCn7.Equals(value) Then
                _ncCn7 = value
                PropertyHasChanged("NcCn7")
            End If
        End Set
    End Property

    Private _ncCn8 As String = String.Empty
    <CellInfo(GroupName:="Analysis")>
    Public Property NcCn8() As String
        Get
            Return _ncCn8
        End Get
        Set(ByVal value As String)
            CanWriteProperty("NcCn8", True)
            If value Is Nothing Then value = String.Empty
            If Not _ncCn8.Equals(value) Then
                _ncCn8 = value
                PropertyHasChanged("NcCn8")
            End If
        End Set
    End Property

    Private _ncCn9 As String = String.Empty
    <CellInfo(GroupName:="Analysis")>
    Public Property NcCn9() As String
        Get
            Return _ncCn9
        End Get
        Set(ByVal value As String)
            CanWriteProperty("NcCn9", True)
            If value Is Nothing Then value = String.Empty
            If Not _ncCn9.Equals(value) Then
                _ncCn9 = value
                PropertyHasChanged("NcCn9")
            End If
        End Set
    End Property

    Private _allocation As String = String.Empty
    <CellInfo(GroupName:="Allocation", Tips:="Allocation")>
    Public Property Allocation() As String
        Get
            Return _allocation
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Allocation", True)
            If value Is Nothing Then value = String.Empty
            If Not _allocation.Equals(value) Then
                _allocation = value
                PropertyHasChanged("Allocation")
            End If
        End Set
    End Property

    Private _allocRef As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
    <CellInfo(GroupName:="Allocation", Tips:="Allocation reference number")>
    Public Property AllocRef() As String
        Get
            Return _allocRef.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("AllocRef", True)
            If value Is Nothing Then value = String.Empty
            If Not _allocRef.Equals(value) Then
                _allocRef.Text = value
                PropertyHasChanged("AllocRef")
            End If
        End Set
    End Property

    Private _allocDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(LinkCode.Calendar, GroupName:="Allocation", Tips:="Enter allocation date")>
    Public Property AllocDate() As String
        Get
            Return _allocDate.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("AllocDate", True)
            If value Is Nothing Then value = String.Empty
            If Not _allocDate.Equals(value) Then
                _allocDate.Text = value
                PropertyHasChanged("AllocDate")
            End If
        End Set
    End Property

    Private _allocPeriod As SmartPeriod = New pbs.Helper.SmartPeriod()
    <CellInfo(GroupName:="Allocation", Tips:="Enter allocation period")>
    Public Property AllocPeriod() As String
        Get
            Return _allocPeriod.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("AllocPeriod", True)
            If value Is Nothing Then value = String.Empty
            If Not _allocPeriod.Equals(value) Then
                _allocPeriod.Text = value
                PropertyHasChanged("AllocPeriod")
            End If
        End Set
    End Property

    Private _status As String = String.Empty
    <CellInfo(GroupName:="Transaction", Tips:="Enter transaction status")>
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Status", True)
            If value Is Nothing Then value = String.Empty
            If Not _status.Equals(value) Then
                _status = value
                PropertyHasChanged("Status")
            End If
        End Set
    End Property

    Private _lockFlag As String = String.Empty
    <CellInfo(GroupName:="Posting", Tips:="Lock flag")>
    Public Property LockFlag() As String
        Get
            Return _lockFlag
        End Get
        Set(ByVal value As String)
            CanWriteProperty("LockFlag", True)
            If value Is Nothing Then value = String.Empty
            If Not _lockFlag.Equals(value) Then
                _lockFlag = value
                PropertyHasChanged("LockFlag")
            End If
        End Set
    End Property

    Private _postingDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(GroupName:="Posting", Tips:="Enter posting date")>
    Public Property PostingDate() As String
        Get
            Return _postingDate.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("PostingDate", True)
            If value Is Nothing Then value = String.Empty
            If Not _postingDate.Equals(value) Then
                _postingDate.Text = value
                PropertyHasChanged("PostingDate")
            End If
        End Set
    End Property

    Private _postedBy As String = String.Empty
    <CellInfo(GroupName:="Posting", Tips:="Posted by")>
    Public Property PostedBy() As String
        Get
            Return _postedBy
        End Get
        Set(ByVal value As String)
            CanWriteProperty("PostedBy", True)
            If value Is Nothing Then value = String.Empty
            If Not _postedBy.Equals(value) Then
                _postedBy = value
                PropertyHasChanged("PostedBy")
            End If
        End Set
    End Property

    Private _holdOpId As String = String.Empty
    <CellInfo(GroupName:="Posting", Tips:="Hold open by")>
    Public Property HoldOpId() As String
        Get
            Return _holdOpId
        End Get
        Set(ByVal value As String)
            CanWriteProperty("HoldOpId", True)
            If value Is Nothing Then value = String.Empty
            If Not _holdOpId.Equals(value) Then
                _holdOpId = value
                PropertyHasChanged("HoldOpId")
            End If
        End Set
    End Property

    Private _bphNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
    <CellInfo(GroupName:="Batch Posting")>
    Public Property BphNo() As String
        Get
            Return _bphNo.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("BphNo", True)
            If value Is Nothing Then value = String.Empty
            If Not _bphNo.Equals(value) Then
                _bphNo.Text = value
                PropertyHasChanged("BphNo")
            End If
        End Set
    End Property

    Private _pfdNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
    <CellInfo(GroupName:="Batch Posting")>
    Public Property PfdNo() As String
        Get
            Return _pfdNo.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("PfdNo", True)
            If value Is Nothing Then value = String.Empty
            If Not _pfdNo.Equals(value) Then
                _pfdNo.Text = value
                PropertyHasChanged("PfdNo")
            End If
        End Set
    End Property

    Private _extDesc1 As String = String.Empty
    <CellInfo(GroupName:="Extended Description")>
    Public Property ExtDesc1() As String
        Get
            Return _extDesc1
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtDesc1", True)
            If value Is Nothing Then value = String.Empty
            If Not _extDesc1.Equals(value) Then
                _extDesc1 = value
                PropertyHasChanged("ExtDesc1")
            End If
        End Set
    End Property

    Private _extDesc2 As String = String.Empty
    <CellInfo(GroupName:="Extended Description")>
    Public Property ExtDesc2() As String
        Get
            Return _extDesc2
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtDesc2", True)
            If value Is Nothing Then value = String.Empty
            If Not _extDesc2.Equals(value) Then
                _extDesc2 = value
                PropertyHasChanged("ExtDesc2")
            End If
        End Set
    End Property

    Private _extDesc3 As String = String.Empty
    <CellInfo(GroupName:="Extended Description")>
    Public Property ExtDesc3() As String
        Get
            Return _extDesc3
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtDesc3", True)
            If value Is Nothing Then value = String.Empty
            If Not _extDesc3.Equals(value) Then
                _extDesc3 = value
                PropertyHasChanged("ExtDesc3")
            End If
        End Set
    End Property

    Private _extDesc4 As String = String.Empty
    <CellInfo(GroupName:="Extended Description")>
    Public Property ExtDesc4() As String
        Get
            Return _extDesc4
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtDesc4", True)
            If value Is Nothing Then value = String.Empty
            If Not _extDesc4.Equals(value) Then
                _extDesc4 = value
                PropertyHasChanged("ExtDesc4")
            End If
        End Set
    End Property

    Private _extDesc5 As String = String.Empty
    <CellInfo(GroupName:="Extended Description")>
    Public Property ExtDesc5() As String
        Get
            Return _extDesc5
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtDesc5", True)
            If value Is Nothing Then value = String.Empty
            If Not _extDesc5.Equals(value) Then
                _extDesc5 = value
                PropertyHasChanged("ExtDesc5")
            End If
        End Set
    End Property

    Private _extDate1 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(GroupName:="Extended Date")>
    Public Property ExtDate1() As String
        Get
            Return _extDate1.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtDate1", True)
            If value Is Nothing Then value = String.Empty
            If Not _extDate1.Equals(value) Then
                _extDate1.Text = value
                PropertyHasChanged("ExtDate1")
            End If
        End Set
    End Property

    Private _extDate2 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(GroupName:="Extended Date")>
    Public Property ExtDate2() As String
        Get
            Return _extDate2.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtDate2", True)
            If value Is Nothing Then value = String.Empty
            If Not _extDate2.Equals(value) Then
                _extDate2.Text = value
                PropertyHasChanged("ExtDate2")
            End If
        End Set
    End Property

    Private _extDate3 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(GroupName:="Extended Date")>
    Public Property ExtDate3() As String
        Get
            Return _extDate3.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtDate3", True)
            If value Is Nothing Then value = String.Empty
            If Not _extDate3.Equals(value) Then
                _extDate3.Text = value
                PropertyHasChanged("ExtDate3")
            End If
        End Set
    End Property

    Private _extDate4 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(GroupName:="Extended Date")>
    Public Property ExtDate4() As String
        Get
            Return _extDate4.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtDate4", True)
            If value Is Nothing Then value = String.Empty
            If Not _extDate4.Equals(value) Then
                _extDate4.Text = value
                PropertyHasChanged("ExtDate4")
            End If
        End Set
    End Property

    Private _extDate5 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(GroupName:="Extended Date")>
    Public Property ExtDate5() As String
        Get
            Return _extDate5.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtDate5", True)
            If value Is Nothing Then value = String.Empty
            If Not _extDate5.Equals(value) Then
                _extDate5.Text = value
                PropertyHasChanged("ExtDate5")
            End If
        End Set
    End Property

    Private _extVal1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(GroupName:="Extended Value")>
    Public Property ExtVal1() As String
        Get
            Return _extVal1.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtVal1", True)
            If value Is Nothing Then value = String.Empty
            If Not _extVal1.Equals(value) Then
                _extVal1.Text = value
                PropertyHasChanged("ExtVal1")
            End If
        End Set
    End Property

    Private _extVal2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(GroupName:="Extended Value")>
    Public Property ExtVal2() As String
        Get
            Return _extVal2.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtVal2", True)
            If value Is Nothing Then value = String.Empty
            If Not _extVal2.Equals(value) Then
                _extVal2.Text = value
                PropertyHasChanged("ExtVal2")
            End If
        End Set
    End Property

    Private _extVal3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(GroupName:="Extended Value")>
    Public Property ExtVal3() As String
        Get
            Return _extVal3.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtVal3", True)
            If value Is Nothing Then value = String.Empty
            If Not _extVal3.Equals(value) Then
                _extVal3.Text = value
                PropertyHasChanged("ExtVal3")
            End If
        End Set
    End Property

    Private _extVal4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(GroupName:="Extended Value")>
    Public Property ExtVal4() As String
        Get
            Return _extVal4.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtVal4", True)
            If value Is Nothing Then value = String.Empty
            If Not _extVal4.Equals(value) Then
                _extVal4.Text = value
                PropertyHasChanged("ExtVal4")
            End If
        End Set
    End Property

    Private _extVal5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(GroupName:="Extended Value")>
    Public Property ExtVal5() As String
        Get
            Return _extVal5.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ExtVal5", True)
            If value Is Nothing Then value = String.Empty
            If Not _extVal5.Equals(value) Then
                _extVal5.Text = value
                PropertyHasChanged("ExtVal5")
            End If
        End Set
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

#End Region 'Business Properties and Methods

#Region "Validation Rules"

    Private Sub AddSharedCommonRules()
        'Sample simple custom rule
        'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

        'Sample dependent property. when check one , check the other as well
        'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
    End Sub

    Protected Overrides Sub AddBusinessRules()
        AddSharedCommonRules()

        For Each _field As ClassField In ClassSchema(Of LEDGER)._fieldList
            If _field.Required Then
                ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.StringRequired, _field.FieldName, 0)
            End If
            If Not String.IsNullOrEmpty(_field.RegexPattern) Then
                ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.RegExMatch, New RegExRuleArgs(_field.FieldName, _field.RegexPattern), 1)
            End If
            '----------using lookup, if no user lookup defined, fallback to predefined by developer----------------------------
            If CATMAPInfoList.ContainsCode(_field) Then
                ValidationRules.AddRule(AddressOf LKUInfoList.ContainsLiveCode, _field.FieldName, 2)
                'Else
                '    Select Case _field.FieldName
                '        Case "LocType"
                '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationType))
                '        Case "Status"
                '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationStatus))
                '    End Select
            End If
        Next
        pbs.BO.Rules.BusinessRules.RegisterBusinessRules(Me)
        MyBase.AddBusinessRules()
    End Sub
#End Region ' Validation

#Region " Factory Methods "

    Private Sub New()
        _DTB = Context.CurrentBECode
        _transDate.Text = ToDay.ToSunDate
        _period.Text = ToDay.Month
    End Sub

    Public Shared Function BlankLEDGER() As LEDGER
        Return New LEDGER
    End Function

    Public Shared Function NewLEDGER(ByVal pLineNo As String) As LEDGER
        'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("LEDGER")))
        Return DataPortal.Create(Of LEDGER)(New Criteria(pLineNo.ToInteger))
    End Function

    Public Shared Function NewBO(ByVal ID As String) As LEDGER
        Dim pLineNo As String = ID.Trim

        Return NewLEDGER(pLineNo)
    End Function

    Public Shared Function GetLEDGER(ByVal pLineNo As String) As LEDGER
        Return DataPortal.Fetch(Of LEDGER)(New Criteria(pLineNo.ToInteger))
    End Function

    Public Shared Function GetBO(ByVal ID As String) As LEDGER
        Dim pLineNo As String = ID.Trim

        Return GetLEDGER(pLineNo)
    End Function

    Public Shared Sub DeleteLEDGER(ByVal pLineNo As String)
        DataPortal.Delete(New Criteria(pLineNo.ToInteger))
    End Sub

    Public Overrides Function Save() As LEDGER
        If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
        If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("LEDGER")))

        Me.ApplyEdit()
        LEDGERInfoList.InvalidateCache()
        Return MyBase.Save()
    End Function

    Public Function CloneLEDGER(ByVal pLineNo As String) As LEDGER

        'If LEDGER.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

        Dim cloningLEDGER As LEDGER = MyBase.Clone
        cloningLEDGER._lineNo = 0
        cloningLEDGER._DTB = Context.CurrentBECode

        'Todo:Remember to reset status of the new object here 
        cloningLEDGER.MarkNew()
        cloningLEDGER.ApplyEdit()

        cloningLEDGER.ValidationRules.CheckRules()

        Return cloningLEDGER
    End Function

#End Region ' Factory Methods

#Region " Data Access "

    <Serializable()> _
    Private Class Criteria
        Public _lineNo As Integer

        Public Sub New(ByVal pLineNo As String)
            _lineNo = pLineNo.ToInteger

        End Sub
    End Class

    <RunLocal()> _
    Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
        _lineNo = criteria._lineNo

        ValidationRules.CheckRules()
    End Sub

    Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
        Using ctx = ConnectionManager.GetManager
            Using cm = ctx.Connection.CreateCommand()
                cm.CommandType = CommandType.Text
                cm.CommandText = <SqlText>SELECT * FROM pbs_PM_LEDGER_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim

                Using dr As New SafeDataReader(cm.ExecuteReader)
                    If dr.Read Then
                        FetchObject(dr)
                        MarkOld()
                    End If
                End Using

            End Using
        End Using
    End Sub

    Private Sub FetchObject(ByVal dr As SafeDataReader)
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
        _ncCn0 = dr.GetString("NC_CN0").TrimEnd
        _ncCn1 = dr.GetString("NC_CN1").TrimEnd
        _ncCn2 = dr.GetString("NC_CN2").TrimEnd
        _ncCn3 = dr.GetString("NC_CN3").TrimEnd
        _ncCn4 = dr.GetString("NC_CN4").TrimEnd
        _ncCn5 = dr.GetString("NC_CN5").TrimEnd
        _ncCn6 = dr.GetString("NC_CN6").TrimEnd
        _ncCn7 = dr.GetString("NC_CN7").TrimEnd
        _ncCn8 = dr.GetString("NC_CN8").TrimEnd
        _ncCn9 = dr.GetString("NC_CN9").TrimEnd
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

    Private Shared _lockObj As New Object
    Protected Overrides Sub DataPortal_Insert()
        SyncLock _lockObj
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.StoredProcedure
                    cm.CommandText = String.Format("pbs_PM_LEDGER_{0}_Insert", _DTB)

                    cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
                    AddInsertParameters(cm)
                    cm.ExecuteNonQuery()

                    _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
                End Using
            End Using
        End SyncLock
    End Sub

    Private Sub AddInsertParameters(ByVal cm As SqlCommand)

        cm.Parameters.AddWithValue("@REFERENCE", _reference.Trim)
        cm.Parameters.AddWithValue("@TRANS_TYPE", _transactionType.Trim)
        cm.Parameters.AddWithValue("@TRANS_DATE", _transDate.DBValue)
        cm.Parameters.AddWithValue("@PERIOD", _period.DBValue)
        cm.Parameters.AddWithValue("@CUSTOMER_CODE", _customerCode.Trim)
        cm.Parameters.AddWithValue("@CONTRACT_NO", _contractNo.Trim)
        cm.Parameters.AddWithValue("@TRANS_AMT", _transAmt.DBValue)
        cm.Parameters.AddWithValue("@CONV_CODE", _convCode.Trim)
        cm.Parameters.AddWithValue("@CONV_RATE", _convRate.DBValue)
        cm.Parameters.AddWithValue("@AMOUNT", _amount.DBValue)
        cm.Parameters.AddWithValue("@D_C", _dC.Trim)
        cm.Parameters.AddWithValue("@PAYMENT_REF", _paymentRef.Trim)
        cm.Parameters.AddWithValue("@PAY_METHOD", _payMethod.Trim)
        cm.Parameters.AddWithValue("@PAYMENT_DATE", _paymentDate.DBValue)
        cm.Parameters.AddWithValue("@PAYMENT_PERIOD", _paymentPeriod.DBValue)
        cm.Parameters.AddWithValue("@INVOICE_NO", _invoiceNo.Trim)
        cm.Parameters.AddWithValue("@INVOICE_SERIAL", _invoiceSerial.Trim)
        cm.Parameters.AddWithValue("@INVOICE_BOOK", _invoiceBook.Trim)
        cm.Parameters.AddWithValue("@INVOICE_DATE", _invoiceDate.DBValue)
        cm.Parameters.AddWithValue("@INVOICE_PERIOD", _invoicePeriod.DBValue)
        cm.Parameters.AddWithValue("@NC_CN0", _ncCn0.Trim)
        cm.Parameters.AddWithValue("@NC_CN1", _ncCn1.Trim)
        cm.Parameters.AddWithValue("@NC_CN2", _ncCn2.Trim)
        cm.Parameters.AddWithValue("@NC_CN3", _ncCn3.Trim)
        cm.Parameters.AddWithValue("@NC_CN4", _ncCn4.Trim)
        cm.Parameters.AddWithValue("@NC_CN5", _ncCn5.Trim)
        cm.Parameters.AddWithValue("@NC_CN6", _ncCn6.Trim)
        cm.Parameters.AddWithValue("@NC_CN7", _ncCn7.Trim)
        cm.Parameters.AddWithValue("@NC_CN8", _ncCn8.Trim)
        cm.Parameters.AddWithValue("@NC_CN9", _ncCn9.Trim)
        cm.Parameters.AddWithValue("@ALLOCATION", _allocation.Trim)
        cm.Parameters.AddWithValue("@ALLOC_REF", _allocRef.DBValue)
        cm.Parameters.AddWithValue("@ALLOC_DATE", _allocDate.DBValue)
        cm.Parameters.AddWithValue("@ALLOC_PERIOD", _allocPeriod.DBValue)
        cm.Parameters.AddWithValue("@STATUS", _status.Trim)
        cm.Parameters.AddWithValue("@LOCK_FLAG", _lockFlag.Trim)
        cm.Parameters.AddWithValue("@POSTING_DATE", _postingDate.DBValue)
        cm.Parameters.AddWithValue("@POSTED_BY", _postedBy.Trim)
        cm.Parameters.AddWithValue("@HOLD_OP_ID", _holdOpId.Trim)
        cm.Parameters.AddWithValue("@BPH_NO", _bphNo.DBValue)
        cm.Parameters.AddWithValue("@PFD_NO", _pfdNo.DBValue)
        cm.Parameters.AddWithValue("@EXT_DESC1", _extDesc1.Trim)
        cm.Parameters.AddWithValue("@EXT_DESC2", _extDesc2.Trim)
        cm.Parameters.AddWithValue("@EXT_DESC3", _extDesc3.Trim)
        cm.Parameters.AddWithValue("@EXT_DESC4", _extDesc4.Trim)
        cm.Parameters.AddWithValue("@EXT_DESC5", _extDesc5.Trim)
        cm.Parameters.AddWithValue("@EXT_DATE1", _extDate1.DBValue)
        cm.Parameters.AddWithValue("@EXT_DATE2", _extDate2.DBValue)
        cm.Parameters.AddWithValue("@EXT_DATE3", _extDate3.DBValue)
        cm.Parameters.AddWithValue("@EXT_DATE4", _extDate4.DBValue)
        cm.Parameters.AddWithValue("@EXT_DATE5", _extDate5.DBValue)
        cm.Parameters.AddWithValue("@EXT_VAL1", _extVal1.DBValue)
        cm.Parameters.AddWithValue("@EXT_VAL2", _extVal2.DBValue)
        cm.Parameters.AddWithValue("@EXT_VAL3", _extVal3.DBValue)
        cm.Parameters.AddWithValue("@EXT_VAL4", _extVal4.DBValue)
        cm.Parameters.AddWithValue("@EXT_VAL5", _extVal5.DBValue)
    End Sub


    Protected Overrides Sub DataPortal_Update()
        SyncLock _lockObj
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.StoredProcedure
                    cm.CommandText = String.Format("pbs_PM_LEDGER_{0}_Update", _DTB)

                    cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
                    AddInsertParameters(cm)
                    cm.ExecuteNonQuery()

                End Using
            End Using
        End SyncLock
    End Sub

    Protected Overrides Sub DataPortal_DeleteSelf()
        DataPortal_Delete(New Criteria(_lineNo))
    End Sub

    Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)
        Using ctx = ConnectionManager.GetManager
            Using cm = ctx.Connection.CreateCommand()

                cm.CommandType = CommandType.Text
                cm.CommandText = <SqlText>DELETE pbs_PM_LEDGER_<%= _DTB %> WHERE LINE_NO = <%= criteria._lineNo %></SqlText>.Value.Trim
                cm.ExecuteNonQuery()

            End Using
        End Using

    End Sub

    'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
    '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
    '        LEDGERInfoList.InvalidateCache()
    '    End If
    'End Sub

#End Region 'Data Access                           

#Region " Exists "
    Public Shared Function Exists(ByVal pLineNo As String) As Boolean
        Return LEDGERInfoList.ContainsCode(pLineNo)
    End Function

    'Public Shared Function KeyDuplicated(ByVal pLineNo As SmartInt32) As Boolean
    '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_PM_LEDGER_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
    '    Return SQLCommander.GetScalarInteger(SqlText) > 0
    'End Function
#End Region

#Region " IGenpart "

    Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
        Return CloneLEDGER(id)
    End Function

    Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
        Return GetBO(id)
    End Function

    Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
        Return pbs.Helper.Action.StandardReferenceCommands
    End Function

    Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
        Return GetType(LEDGER).ToString
    End Function

    Public Function myName() As String Implements Interfaces.IGenPartObject.myName
        Return GetType(LEDGER).ToString.Leaf
    End Function

    Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
        Return LEDGERInfoList.GetLEDGERInfoList
    End Function
#End Region

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