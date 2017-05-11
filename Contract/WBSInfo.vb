
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

'Namespace PM

<Serializable()> _
Public Class WBSInfo
    Inherits Csla.ReadOnlyBase(Of WBSInfo)
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

    Private _contractNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
    Public ReadOnly Property ContractNo() As String
        Get
            Return _contractNo.Text
        End Get
    End Property

    Private _wbs As String = String.Empty
    Public ReadOnly Property Wbs() As String
        Get
            Return _wbs
        End Get
    End Property

    Private _descriptn As String = String.Empty
    Public ReadOnly Property Descriptin() As String
        Get
            Return _descriptn
        End Get
    End Property

    Private _unit As String = String.Empty
    Public ReadOnly Property Unit() As String
        Get
            Return _unit
        End Get
    End Property

    Private _workVolume As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property WorkVolume() As String
        Get
            Return _workVolume.Text
        End Get
    End Property

    Private _labor As String = String.Empty
    Public ReadOnly Property Labor() As String
        Get
            Return _labor
        End Get
    End Property

    Private _materials As String = String.Empty
    Public ReadOnly Property Materials() As String
        Get
            Return _materials
        End Get
    End Property

    Private _machines As String = String.Empty
    Public ReadOnly Property Machines() As String
        Get
            Return _machines
        End Get
    End Property

    Private _unitPrice As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property UnitPrice() As String
        Get
            Return _unitPrice.Text
        End Get
    End Property

    Private _totalAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property TotalAmount() As String
        Get
            Return _totalAmount.Text
        End Get
    End Property

    Private _performFromDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property PerformFromDate() As String
        Get
            Return _performFromDate.DateViewFormat
        End Get
    End Property

    Private _perfromToDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property PerfromToDate() As String
        Get
            Return _perfromToDate.DateViewFormat
        End Get
    End Property

    Private _perfromedBy As String = String.Empty
    Public ReadOnly Property PerformedBy() As String
        Get
            Return _perfromedBy
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
            Return String.Format("Work Breakdown Structure: {0}, Contract number: {1}", _wbs, _contractNo)
        End Get
    End Property


    Public Sub InvalidateCache() Implements IInfo.InvalidateCache
        WBSInfoList.InvalidateCache()
    End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

    Friend Shared Function GetWBSInfo(ByVal dr As SafeDataReader) As WBSInfo
        Return New WBSInfo(dr)
    End Function

    Friend Shared Function EmptyWBSInfo(Optional ByVal pLineNo As String = "") As WBSInfo
        Dim info As WBSInfo = New WBSInfo
        With info
            ._lineNo = pLineNo.ToInteger

        End With
        Return info
    End Function

    Private Sub New(ByVal dr As SafeDataReader)
        _lineNo = dr.GetInt32("LINE_NO")
        _contractNo.Text = dr.GetInt32("CONTRACT_NO")
        _wbs = dr.GetString("WBS").TrimEnd
        _descriptn = dr.GetString("DESCRIPTION").TrimEnd
        _unit = dr.GetString("UNIT").TrimEnd
        _workVolume.Text = dr.GetDecimal("WORK_VOLUME")
        _labor = dr.GetString("LABOR").TrimEnd
        _materials = dr.GetString("MATERIALS").TrimEnd
        _machines = dr.GetString("MACHINES").TrimEnd
        _unitPrice.Text = dr.GetDecimal("UNIT_PRICE")
        _totalAmount.Text = dr.GetDecimal("TOTAL_AMOUNT")
        _performFromDate.Text = dr.GetInt32("PERFORM_FROM_DATE")
        _perfromToDate.Text = dr.GetInt32("PERFORM_TO_DATE")
        _perfromedBy = dr.GetString("PERFORMED_BY")
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