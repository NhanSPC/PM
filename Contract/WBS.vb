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
<DB(TableName:="pbs_PM_WBS_{XXX}")>
Public Class WBS
    Inherits Csla.BusinessBase(Of WBS)
    Implements Interfaces.IGenPartObject
    Implements IComparable
    Implements IDocLink



#Region "Property Changed"
    Protected Overrides Sub OnDeserialized(context As Runtime.Serialization.StreamingContext)
        MyBase.OnDeserialized(context)
        AddHandler Me.PropertyChanged, AddressOf BO_PropertyChanged
    End Sub

    Private Sub BO_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles Me.PropertyChanged
        'Select Case e.PropertyName

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

        'End Select

        pbs.BO.Rules.CalculationRules.Calculator(sender, e)
    End Sub
#End Region

#Region " Business Properties and Methods "
    Friend _DTB As String = String.Empty


    Friend _lineNo As Integer
    <System.ComponentModel.DataObjectField(True, True)> _
    <CellInfo(Hidden:=True)>
    Public ReadOnly Property LineNo() As String
        Get
            Return _lineNo
        End Get
    End Property

    Private _contractNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
    <CellInfo("pbs.BO.PM.CTR", Tips:="Enter contract number")>
    Public Property ContractNo() As String
        Get
            Return _contractNo.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ContractNo", True)
            If value Is Nothing Then value = String.Empty
            If Not _contractNo.Equals(value) Then
                _contractNo.Text = value
                PropertyHasChanged("ContractNo")
            End If
        End Set
    End Property

    Private _wbs As String = String.Empty
    <CellInfo(Tips:="Enter Work Breakdown Structure")>
    <Rule(Required:=True)>
    Public Property Wbs() As String
        Get
            Return _wbs
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Wbs", True)
            If value Is Nothing Then value = String.Empty
            If Not _wbs.Equals(value) Then
                _wbs = value
                PropertyHasChanged("Wbs")
            End If
        End Set
    End Property

    Private _descriptn As String = String.Empty
    <CellInfo(Tips:="Enter Work Breakdown Structure description")>
    Public Property Descriptin() As String
        Get
            Return _descriptn
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Descriptin", True)
            If value Is Nothing Then value = String.Empty
            If Not _descriptn.Equals(value) Then
                _descriptn = value
                PropertyHasChanged("Descriptin")
            End If
        End Set
    End Property

    Private _unit As String = String.Empty
    <CellInfo(Tips:="Enter unit")>
    Public Property Unit() As String
        Get
            Return _unit
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Unit", True)
            If value Is Nothing Then value = String.Empty
            If Not _unit.Equals(value) Then
                _unit = value
                PropertyHasChanged("Unit")
            End If
        End Set
    End Property

    Private _workVolume As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(Tips:="Enter weigh")>
    Public Property WokVolume() As String
        Get
            Return _workVolume.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("WokVolume", True)
            If value Is Nothing Then value = String.Empty
            If Not _workVolume.Equals(value) Then
                _workVolume.Text = value
                PropertyHasChanged("WokVolume")
            End If
        End Set
    End Property

    Private _labor As String = String.Empty
    <CellInfo(Tips:="", ControlType:=Forms.CtrlType.CheckBox)>
    Public Property Labor() As Boolean
        Get
            Return _labor.ToBoolean
        End Get
        Set(ByVal value As Boolean)
            CanWriteProperty("Labor", True)
            If Not _labor.Equals(value) Then
                _labor = If(value, "Y", "N")
                PropertyHasChanged("Labor")
            End If
        End Set
    End Property

    Private _materials As String = String.Empty
    <CellInfo(Tips:="", ControlType:=Forms.CtrlType.CheckBox)>
    Public Property Materials() As Boolean
        Get
            Return _materials.ToBoolean
        End Get
        Set(ByVal value As Boolean)
            CanWriteProperty("Materials", True)
            If Not _materials.Equals(value) Then
                _materials = If(value, "Y", "N")
                PropertyHasChanged("Materials")
            End If
        End Set
    End Property

    Private _machines As String = String.Empty
    <CellInfo(Tips:="", ControlType:=Forms.CtrlType.CheckBox)>
    Public Property Machines() As Boolean
        Get
            Return _machines.ToBoolean
        End Get
        Set(ByVal value As Boolean)
            CanWriteProperty("Machines", True)
            If Not _machines.Equals(value) Then
                _machines = If(value, "Y", "N")
                PropertyHasChanged("Machines")
            End If
        End Set
    End Property

    Private _unitPrice As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(Tips:="Enter unit price")>
    Public Property UnitPrice() As String
        Get
            Return _unitPrice.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("UnitPrice", True)
            If value Is Nothing Then value = String.Empty
            If Not _unitPrice.Equals(value) Then
                _unitPrice.Text = value
                PropertyHasChanged("UnitPrice")
            End If
        End Set
    End Property

    Private _totalAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(Tips:="Enter Total amount")>
    Public Property TotalAmount() As String
        Get
            Return _totalAmount.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("TotalAmount", True)
            If value Is Nothing Then value = String.Empty
            If Not _totalAmount.Equals(value) Then
                _totalAmount.Text = value
                PropertyHasChanged("TotalAmount")
            End If
        End Set
    End Property

    Private _performFromDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate
    <CellInfo(LinkCode.Calendar, Tips:="Enter the date that construction is performed")>
    Public Property PerformFromDate() As String
        Get
            Return _performFromDate.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("PerformFromDate", True)
            If value Is Nothing Then value = String.Empty
            If Not _performFromDate.Equals(value) Then
                _performFromDate.Text = value
                PropertyHasChanged("PerformFromDate")
            End If
        End Set
    End Property

    Private _performToDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate
    <CellInfo(LinkCode.Calendar, Tips:="Enter the date that construction is completed")>
    Public Property PerformTo() As String
        Get
            Return _performToDate.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("PerformToDate", True)
            If value Is Nothing Then value = String.Empty
            If Not _performToDate.Equals(value) Then
                _performToDate.Text = value
                PropertyHasChanged("PerformToDate")
            End If
        End Set
    End Property

    Private _perfromedBy As String = String.Empty
    Public Property PerformedBy() As String
        Get
            Return _perfromedBy
        End Get
        Set(ByVal value As String)
            CanWriteProperty("PerformedBy", True)
            If value Is Nothing Then value = String.Empty
            If Not _perfromedBy.Equals(value) Then
                _perfromedBy = value
                PropertyHasChanged("PerformedBy")
            End If
        End Set
    End Property

    Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(Hidden:=True)>
    Public ReadOnly Property Updated() As String
        Get
            Return _updated.Text
        End Get
    End Property

    Private _updatedBy As String = String.Empty
    <CellInfo(Hidden:=True)>
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

#End Region 'Business Properties and Methods

#Region "Validation Rules"

    Friend Sub CheckRules()
        ValidationRules.CheckRules()
    End Sub

    Private Sub AddSharedCommonRules()
        'Sample simple custom rule
        'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

        'Sample dependent property. when check one , check the other as well
        'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
    End Sub

    Protected Overrides Sub AddBusinessRules()
        AddSharedCommonRules()

        For Each _field As ClassField In ClassSchema(Of WBS)._fieldList
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
    End Sub

    Public Shared Function BlankWBS() As WBS
        Return New WBS
    End Function

    Public Shared Function NewWBS(ByVal pLineNo As String) As WBS
        'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("WBS")))
        Return DataPortal.Create(Of WBS)(New Criteria(pLineNo.ToInteger))
    End Function

    Public Shared Function NewBO(ByVal ID As String) As WBS
        Dim pLineNo As String = ID.Trim

        Return NewWBS(pLineNo)
    End Function

    Public Shared Function GetWBS(ByVal pLineNo As String) As WBS
        Return DataPortal.Fetch(Of WBS)(New Criteria(pLineNo.ToInteger))
    End Function

    Public Shared Function GetBO(ByVal ID As String) As WBS
        Dim pLineNo As String = ID.Trim

        Return GetWBS(pLineNo)
    End Function

    Public Shared Sub DeleteWBS(ByVal pLineNo As String)
        DataPortal.Delete(New Criteria(pLineNo.ToInteger))
    End Sub

    Public Overrides Function Save() As WBS
        If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
        If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("WBS")))

        Me.ApplyEdit()
        WBSInfoList.InvalidateCache()
        Return MyBase.Save()
    End Function

    Public Function CloneWBS(ByVal pLineNo As String) As WBS

        'If Wbs.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

        Dim cloningWBS As WBS = MyBase.Clone
        cloningWBS._lineNo = 0
        cloningWBS._DTB = Context.CurrentBECode

        'Todo:Remember to reset status of the new object here 
        cloningWBS.MarkNew()
        cloningWBS.ApplyEdit()

        cloningWBS.ValidationRules.CheckRules()

        Return cloningWBS
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
                cm.CommandText = <SqlText>SELECT * FROM pbs_PM_WBS_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim

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
        _performToDate.Text = dr.GetInt32("PERFORM_TO_DATE")
        _perfromedBy = dr.GetString("PERFORMED_BY")
        _updated.Text = dr.GetInt32("UPDATED")
        _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

    End Sub

    Private Shared _lockObj As New Object
    Protected Overrides Sub DataPortal_Insert()
        SyncLock _lockObj
            Using ctx = ConnectionManager.GetManager
                'Using cm = ctx.Connection.CreateCommand()

                '    cm.CommandType = CommandType.StoredProcedure
                '    cm.CommandText = String.Format("pbs_PM_WBS_{0}_Insert", _DTB)

                '    cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
                '    AddInsertParameters(cm)
                '    cm.ExecuteNonQuery()

                '    _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
                'End Using

                Insert(ctx.Connection)
            End Using
        End SyncLock
    End Sub

    Private Sub AddInsertParameters(ByVal cm As SqlCommand)
        cm.Parameters.AddWithValue("@CONTRACT_NO", _contractNo.DBValue)
        cm.Parameters.AddWithValue("@WBS", _wbs.Trim)
        cm.Parameters.AddWithValue("@DESCRIPTION", _descriptn)
        cm.Parameters.AddWithValue("@UNIT", _unit.Trim)
        cm.Parameters.AddWithValue("@WORK_VOLUME", _workVolume.DBValue)
        cm.Parameters.AddWithValue("@LABOR", _labor.Trim)
        cm.Parameters.AddWithValue("@MATERIALS", _materials.Trim)
        cm.Parameters.AddWithValue("@MACHINES", _machines.Trim)
        cm.Parameters.AddWithValue("@UNIT_PRICE", _unitPrice.DBValue)
        cm.Parameters.AddWithValue("@TOTAL_AMOUNT", _totalAmount.DBValue)
        cm.Parameters.AddWithValue("@PERFORM_FROM_DATE", _performFromDate.DBValue)
        cm.Parameters.AddWithValue("@PERFORM_TO_DATE", _performToDate.DBValue)
        cm.Parameters.AddWithValue("@PERFORMED_BY", _perfromedBy)
        cm.Parameters.AddWithValue("@UPDATED", ToDay.ToSunDate)
        cm.Parameters.AddWithValue("@UPDATED_BY", Context.CurrentUserCode)
    End Sub


    Protected Overrides Sub DataPortal_Update()
        SyncLock _lockObj
            Using ctx = ConnectionManager.GetManager
                'Using cm = ctx.Connection.CreateCommand()

                '    cm.CommandType = CommandType.StoredProcedure
                '    cm.CommandText = String.Format("pbs_PM_WBS_{0}_Update", _DTB)

                '    cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
                '    AddInsertParameters(cm)
                '    cm.ExecuteNonQuery()

                'End Using

                Update(ctx.Connection)
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
                cm.CommandText = <SqlText>DELETE pbs_PM_WBS_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim
                cm.ExecuteNonQuery()

            End Using
        End Using

    End Sub

    'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
    '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
    '        WBSInfoList.InvalidateCache()
    '    End If
    'End Sub


#End Region 'Data Access                           

#Region " Exists "
    Public Shared Function Exists(ByVal pLineNo As String) As Boolean
        Return WBSInfoList.ContainsCode(pLineNo)
    End Function

    'Public Shared Function KeyDuplicated(ByVal pLineNo As SmartInt32) As Boolean
    '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_PM_WBS_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
    '    Return SQLCommander.GetScalarInteger(SqlText) > 0
    'End Function
#End Region

#Region " IGenpart "

    Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
        Return CloneWBS(id)
    End Function

    Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
        Return GetBO(id)
    End Function

    Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
        Return pbs.Helper.Action.StandardReferenceCommands
    End Function

    Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
        Return GetType(WBS).ToString
    End Function

    Public Function myName() As String Implements Interfaces.IGenPartObject.myName
        Return GetType(WBS).ToString.Leaf
    End Function

    Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
        Return WBSInfoList.GetWBSInfoList
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

#Region "Child"
    Shared Function NewWBSChild(pContractNo As String) As WBS
        Dim ret = New WBS
        ret._contractNo.Text = pContractNo
        ret.MarkAsChild()
        Return ret
    End Function

    Shared Function GetChildWBS(dr As SafeDataReader)
        Dim child = New WBS
        child.FetchObject(dr)
        child.MarkAsChild()
        child.MarkOld()
        Return child
    End Function

    Sub DeleteSelf(cn As SqlConnection)
        Using cm = cn.CreateCommand
            cm.CommandType = CommandType.Text
            cm.CommandText = <sqltext>DELETE pbs_PM_WBS_<%= _DTB %> WHERE LINE_NO = <%= _lineNo %></sqltext>
            cm.ExecuteNonQuery()
        End Using
    End Sub

    Sub Insert(cn As SqlConnection)
        Using cm = cn.CreateCommand
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandText = String.Format("pbs_PM_WBS_{0}_Insert", _DTB)

            cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
            AddInsertParameters(cm)
            cm.ExecuteNonQuery()

            _lineNo = CInt(cm.Parameters("@LINE_NO").Value)

            MarkOld()
        End Using
    End Sub

    Sub Update(cn As SqlConnection)

        Using cm = cn.CreateCommand()

            cm.CommandType = CommandType.StoredProcedure
            cm.CommandText = String.Format("pbs_PM_WBS_{0}_Update", _DTB)

            cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
            AddInsertParameters(cm)
            cm.ExecuteNonQuery()

            MarkOld()
        End Using

    End Sub

    Sub MarkAsNewChild()
        MarkNew()
    End Sub
#End Region

End Class

'End Namespace