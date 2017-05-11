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
<DB(TableName:="pbs_PM_PROGRESS_{XXX}")>
Public Class PROGRESS
    Inherits Csla.BusinessBase(Of PROGRESS)
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
    Private _DTB As String = String.Empty


    Private _lineNo As Integer
    <System.ComponentModel.DataObjectField(True, True)> _
    <CellInfo(Hidden:=True)>
    Public ReadOnly Property LineNo() As String
        Get
            Return _lineNo
        End Get
    End Property

    Private _contractNo As String = String.Empty
    <CellInfo("pbs.BO.PM.CTR", GroupName:="", Tips:="Enter contract number")>
    <Rule(Required:=True)>
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

    Private _appendix As String = String.Empty
    <CellInfo(GroupName:="", Tips:="Enter appendix of the contract")>
    Public Property Appendix() As String
        Get
            Return _appendix
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Appendix", True)
            If value Is Nothing Then value = String.Empty
            If Not _appendix.Equals(value) Then
                _appendix = value
                PropertyHasChanged("Appendix")
            End If
        End Set
    End Property

    Private _projectCode As String = String.Empty
    <CellInfo("pbs.BO.PM.PRJ", GroupName:="", Tips:="Enter project code")>
    Public Property ProjectCode() As String
        Get
            Return _projectCode
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ProjectCode", True)
            If value Is Nothing Then value = String.Empty
            If Not _projectCode.Equals(value) Then
                _projectCode = value
                PropertyHasChanged("ProjectCode")
            End If
        End Set
    End Property

    Private _stageNo As String = String.Empty
    <CellInfo(GroupName:="", Tips:="Enter stage number")>
    Public Property StageNo() As String
        Get
            Return _stageNo
        End Get
        Set(ByVal value As String)
            CanWriteProperty("StageNo", True)
            If value Is Nothing Then value = String.Empty
            If Not _stageNo.Equals(value) Then
                _stageNo = value
                PropertyHasChanged("StageNo")
            End If
        End Set
    End Property

    Private _wbsCode As String = String.Empty
    <CellInfo("pbs.BO.PM.WBS", GroupName:="", Tips:="Enter Work Breakdown Structure code")>
    <Rule(Required:=True)>
    Public Property WbsCode() As String
        Get
            Return _wbsCode
        End Get
        Set(ByVal value As String)
            CanWriteProperty("WbsCode", True)
            If value Is Nothing Then value = String.Empty
            If Not _wbsCode.Equals(value) Then
                _wbsCode = value
                PropertyHasChanged("WbsCode")
            End If
        End Set
    End Property

    Private _inspectionDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="Enter inspection date")>
    Public Property InspectionDate() As String
        Get
            Return _inspectionDate.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("InspectionDate", True)
            If value Is Nothing Then value = String.Empty
            If Not _inspectionDate.Equals(value) Then
                _inspectionDate.Text = value
                PropertyHasChanged("InspectionDate")
            End If
        End Set
    End Property

    Private _inspectionTime As pbs.Helper.SmartTime = New pbs.Helper.SmartTime()
    <CellInfo(GroupName:="", Tips:="Enter inspection time")>
    Public Property InspectionTime() As String
        Get
            Return _inspectionTime.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("InspectionTime", True)
            If value Is Nothing Then value = String.Empty
            If Not _inspectionTime.Equals(value) Then
                _inspectionTime.Text = value
                PropertyHasChanged("InspectionTime")
            End If
        End Set
    End Property

    Private _completedJobProrate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(GroupName:="", Tips:="Enter completed job prorate")>
    Public Property CompletedJobProrate() As String
        Get
            Return _completedJobProrate.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("CompletedJobProrate", True)
            If value Is Nothing Then value = String.Empty
            If Not _completedJobProrate.Equals(value) Then
                _completedJobProrate.Text = value
                PropertyHasChanged("CompletedJobProrate")
            End If
        End Set
    End Property

    Private _completedJob As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    <CellInfo(GroupName:="", Tips:="Enter amount of completed job")>
    Public Property CompletedJob() As String
        Get
            Return _completedJob.Text
        End Get
        Set(ByVal value As String)
            CanWriteProperty("CompletedJob", True)
            If value Is Nothing Then value = String.Empty
            If Not _completedJob.Equals(value) Then
                _completedJob.Text = value
                PropertyHasChanged("CompletedJob")
            End If
        End Set
    End Property

    Private _documentation As String = String.Empty
    <CellInfo(GroupName:="", Tips:="Enter documentation used in inspection")>
    Public Property Documentation() As String
        Get
            Return _documentation
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Documentation", True)
            If value Is Nothing Then value = String.Empty
            If Not _documentation.Equals(value) Then
                _documentation = value
                PropertyHasChanged("Documentation")
            End If
        End Set
    End Property

    Private _jobQualityComment As String = String.Empty
    <CellInfo(GroupName:="", Tips:="Enter job quality comment")>
    Public Property JobQualityComment() As String
        Get
            Return _jobQualityComment
        End Get
        Set(ByVal value As String)
            CanWriteProperty("JobQualityComment", True)
            If value Is Nothing Then value = String.Empty
            If Not _jobQualityComment.Equals(value) Then
                _jobQualityComment = value
                PropertyHasChanged("JobQualityComment")
            End If
        End Set
    End Property

    Private _result As String = String.Empty
    <CellInfo(GroupName:="", Tips:="Enter result of inspection")>
    Public Property Result() As String
        Get
            Return _result
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Result", True)
            If value Is Nothing Then value = String.Empty
            If Not _result.Equals(value) Then
                _result = value
                PropertyHasChanged("Result")
            End If
        End Set
    End Property

    Private _notes As String = String.Empty
    <CellInfo(GroupName:="", Tips:="Notes")>
    Public Property Notes() As String
        Get
            Return _notes
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Notes", True)
            If value Is Nothing Then value = String.Empty
            If Not _notes.Equals(value) Then
                _notes = value
                PropertyHasChanged("Notes")
            End If
        End Set
    End Property

    Private _investor As String = String.Empty
    <CellInfo(GroupName:="", Tips:="Enter name of legal representative of the investor")>
    Public Property Investor() As String
        Get
            Return _investor
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Investor", True)
            If value Is Nothing Then value = String.Empty
            If Not _investor.Equals(value) Then
                _investor = value
                PropertyHasChanged("Investor")
            End If
        End Set
    End Property

    Private _contractor As String = String.Empty
    <CellInfo(GroupName:="", Tips:="Enter name of legal representative of the contractor")>
    Public Property Contractor() As String
        Get
            Return _contractor
        End Get
        Set(ByVal value As String)
            CanWriteProperty("Contractor", True)
            If value Is Nothing Then value = String.Empty
            If Not _contractor.Equals(value) Then
                _contractor = value
                PropertyHasChanged("Contractor")
            End If
        End Set
    End Property

    Private _constructionUnit As String = String.Empty
    <CellInfo(GroupName:="", Tips:="Enter name of legal representative of the construction unit")>
    Public Property ConstructionUnit() As String
        Get
            Return _constructionUnit
        End Get
        Set(ByVal value As String)
            CanWriteProperty("ConstructionUnit", True)
            If value Is Nothing Then value = String.Empty
            If Not _constructionUnit.Equals(value) Then
                _constructionUnit = value
                PropertyHasChanged("ConstructionUnit")
            End If
        End Set
    End Property

    Private _otherParties As String = String.Empty
    <CellInfo(GroupName:="", Tips:="Enter name of legal representative of other parties")>
    Public Property OtherParties() As String
        Get
            Return _otherParties
        End Get
        Set(ByVal value As String)
            CanWriteProperty("OtherParties", True)
            If value Is Nothing Then value = String.Empty
            If Not _otherParties.Equals(value) Then
                _otherParties = value
                PropertyHasChanged("OtherParties")
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

    Private Sub AddSharedCommonRules()
        'Sample simple custom rule
        'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

        'Sample dependent property. when check one , check the other as well
        'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
    End Sub

    Protected Overrides Sub AddBusinessRules()
        AddSharedCommonRules()

        For Each _field As ClassField In ClassSchema(Of PROGRESS)._fieldList
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

    Public Shared Function BlankPROGRESS() As PROGRESS
        Return New PROGRESS
    End Function

    Public Shared Function NewPROGRESS(ByVal pLineNo As String) As PROGRESS
        'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("PROGRESS")))
        Return DataPortal.Create(Of PROGRESS)(New Criteria(pLineNo.ToInteger))
    End Function

    Public Shared Function NewBO(ByVal ID As String) As PROGRESS
        Dim pLineNo As String = ID.Trim

        Return NewPROGRESS(pLineNo)
    End Function

    Public Shared Function GetPROGRESS(ByVal pLineNo As String) As PROGRESS
        Return DataPortal.Fetch(Of PROGRESS)(New Criteria(pLineNo.ToInteger))
    End Function

    Public Shared Function GetBO(ByVal ID As String) As PROGRESS
        Dim pLineNo As String = ID.Trim

        Return GetPROGRESS(pLineNo)
    End Function

    Public Shared Sub DeletePROGRESS(ByVal pLineNo As String)
        DataPortal.Delete(New Criteria(pLineNo.ToInteger))
    End Sub

    Public Overrides Function Save() As PROGRESS
        If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
        If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("PROGRESS")))

        Me.ApplyEdit()
        PROGRESSInfoList.InvalidateCache()
        Return MyBase.Save()
    End Function

    Public Function ClonePROGRESS(ByVal pLineNo As String) As PROGRESS

        'If PROGRESS.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

        Dim cloningPROGRESS As PROGRESS = MyBase.Clone
        cloningPROGRESS._lineNo = 0
        cloningPROGRESS._DTB = Context.CurrentBECode

        'Todo:Remember to reset status of the new object here 
        cloningPROGRESS.MarkNew()
        cloningPROGRESS.ApplyEdit()

        cloningPROGRESS.ValidationRules.CheckRules()

        Return cloningPROGRESS
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
                cm.CommandText = <SqlText>SELECT * FROM pbs_PM_PROGRESS_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim

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
        _contractNo = dr.GetString("CONTRACT_NO").TrimEnd
        _appendix = dr.GetString("APPENDIX").TrimEnd
        _projectCode = dr.GetString("PROJECT_CODE").TrimEnd
        _stageNo = dr.GetString("STAGE_NO").TrimEnd
        _wbsCode = dr.GetString("WBS_CODE").TrimEnd
        _inspectionDate.Text = dr.GetInt32("INSPECTION_DATE")
        _inspectionTime.Text = dr.GetInt32("INSPECTION_TIME")
        _completedJobProrate.Text = dr.GetDecimal("COMPLETED_JOB_PRORATE")
        _completedJob.Text = dr.GetDecimal("COMPLETED_JOB")
        _documentation = dr.GetString("DOCUMENTATION").TrimEnd
        _jobQualityComment = dr.GetString("JOB_QUALITY_COMMENT").TrimEnd
        _result = dr.GetString("RESULT").TrimEnd
        _notes = dr.GetString("NOTES").TrimEnd
        _investor = dr.GetString("INVESTOR").TrimEnd
        _contractor = dr.GetString("CONTRACTOR").TrimEnd
        _constructionUnit = dr.GetString("CONSTRUCTION_UNIT").TrimEnd
        _otherParties = dr.GetString("OTHER_PARTIES").TrimEnd
        _updated.Text = dr.GetInt32("UPDATED")
        _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

    End Sub

    Private Shared _lockObj As New Object
    Protected Overrides Sub DataPortal_Insert()
        SyncLock _lockObj
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.StoredProcedure
                    cm.CommandText = String.Format("pbs_PM_PROGRESS_{0}_Insert", _DTB)

                    cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
                    AddInsertParameters(cm)
                    cm.ExecuteNonQuery()

                    _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
                End Using
            End Using
        End SyncLock
    End Sub

    Private Sub AddInsertParameters(ByVal cm As SqlCommand)
        cm.Parameters.AddWithValue("@CONTRACT_NO", _contractNo.Trim)
        cm.Parameters.AddWithValue("@APPENDIX", _appendix.Trim)
        cm.Parameters.AddWithValue("@PROJECT_CODE", _projectCode.Trim)
        cm.Parameters.AddWithValue("@STAGE_NO", _stageNo.Trim)
        cm.Parameters.AddWithValue("@WBS_CODE", _wbsCode.Trim)
        cm.Parameters.AddWithValue("@INSPECTION_DATE", _inspectionDate.DBValue)
        cm.Parameters.AddWithValue("@INSPECTION_TIME", _inspectionTime.DBValue)
        cm.Parameters.AddWithValue("@COMPLETED_JOB_PRORATE", _completedJobProrate.DBValue)
        cm.Parameters.AddWithValue("@COMPLETED_JOB", _completedJob.DBValue)
        cm.Parameters.AddWithValue("@DOCUMENTATION", _documentation.Trim)
        cm.Parameters.AddWithValue("@JOB_QUALITY_COMMENT", _jobQualityComment.Trim)
        cm.Parameters.AddWithValue("@RESULT", _result.Trim)
        cm.Parameters.AddWithValue("@NOTES", _notes.Trim)
        cm.Parameters.AddWithValue("@INVESTOR", _investor.Trim)
        cm.Parameters.AddWithValue("@CONTRACTOR", _contractor.Trim)
        cm.Parameters.AddWithValue("@CONSTRUCTION_UNIT", _constructionUnit.Trim)
        cm.Parameters.AddWithValue("@OTHER_PARTIES", _otherParties.Trim)
        cm.Parameters.AddWithValue("@UPDATED", _updated.DBValue)
        cm.Parameters.AddWithValue("@UPDATED_BY", _updatedBy.Trim)
    End Sub


    Protected Overrides Sub DataPortal_Update()
        SyncLock _lockObj
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.StoredProcedure
                    cm.CommandText = String.Format("pbs_PM_PROGRESS_{0}_Update", _DTB)

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
                cm.CommandText = <SqlText>DELETE pbs_PM_PROGRESS_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim
                cm.ExecuteNonQuery()

            End Using
        End Using

    End Sub

    'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
    '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
    '        PROGRESSInfoList.InvalidateCache()
    '    End If
    'End Sub


#End Region 'Data Access                           

#Region " Exists "
    Public Shared Function Exists(ByVal pLineNo As String) As Boolean
        Return PROGRESSInfoList.ContainsCode(pLineNo)
    End Function

    'Public Shared Function KeyDuplicated(ByVal pLineNo As SmartInt32) As Boolean
    '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_PM_PROGRESS_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
    '    Return SQLCommander.GetScalarInteger(SqlText) > 0
    'End Function
#End Region

#Region " IGenpart "

    Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
        Return ClonePROGRESS(id)
    End Function

    Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
        Return GetBO(id)
    End Function

    Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
        Return pbs.Helper.Action.StandardReferenceCommands
    End Function

    Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
        Return GetType(PROGRESS).ToString
    End Function

    Public Function myName() As String Implements Interfaces.IGenPartObject.myName
        Return GetType(PROGRESS).ToString.Leaf
    End Function

    Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
        Return PROGRESSInfoList.GetPROGRESSInfoList
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