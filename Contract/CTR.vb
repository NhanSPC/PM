Imports pbs.Helper
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports pbs.BO.DataAnnotations
Imports pbs.BO.Script
Imports pbs.BO.BusinessRules


Namespace PM

    <Serializable()> _
    Public Class CTR
        Inherits Csla.BusinessBase(Of CTR)
        Implements Interfaces.IGenPartObject
        Implements IComparable
        Implements IDocLink



#Region "Property Changed"
        Protected Overrides Sub OnDeserialized(context As Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            AddHandler Me.PropertyChanged, AddressOf BO_PropertyChanged
        End Sub

        Private Sub BO_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles Me.PropertyChanged
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
        <CellInfo(Tips:="Enter number of contract")>
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

        Private _contractDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(Tips:="Enter date of contract")>
        Public Property ContractDate() As String
            Get
                Return _contractDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ContractDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _contractDate.Equals(value) Then
                    _contractDate.Text = value
                    PropertyHasChanged("ContractDate")
                End If
            End Set
        End Property

        Private _contractor As String = String.Empty
        <CellInfo(Tips:="Enter contructor ID")>
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

        Private _contructionUnit As String = String.Empty
        <CellInfo(Tips:="Enter contruction unit ID")>
        Public Property ContructionUnit() As String
            Get
                Return _contructionUnit
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ContructionUnit", True)
                If value Is Nothing Then value = String.Empty
                If Not _contructionUnit.Equals(value) Then
                    _contructionUnit = value
                    PropertyHasChanged("ContructionUnit")
                End If
            End Set
        End Property

        Private _contructionUnitName As String = String.Empty
        <CellInfo(Tips:="Enter contruction unit name in case contruction unit doesn't have ID")>
        Public Property ContructionUnitName() As String
            Get
                Return _contructionUnitName
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ContructionUnitName", True)
                If value Is Nothing Then value = String.Empty
                If Not _contructionUnitName.Equals(value) Then
                    _contructionUnitName = value
                    PropertyHasChanged("ContructionUnitName")
                End If
            End Set
        End Property

        Private _contractType As String = String.Empty
        <CellInfo(Tips:="Enter type of contract. Ex: advisory contract,...")>
        Public Property ContractType() As String
            Get
                Return _contractType
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ContractType", True)
                If value Is Nothing Then value = String.Empty
                If Not _contractType.Equals(value) Then
                    _contractType = value
                    PropertyHasChanged("ContractType")
                End If
            End Set
        End Property

        Private _contractForm As String = String.Empty
        <CellInfo(Tips:="Enter form of contract. Ex: All-in-one contract,...")>
        Public Property ContractForm() As String
            Get
                Return _contractForm
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ContractForm", True)
                If value Is Nothing Then value = String.Empty
                If Not _contractForm.Equals(value) Then
                    _contractForm = value
                    PropertyHasChanged("ContractForm")
                End If
            End Set
        End Property

        Private _currency As String = String.Empty
        <CellInfo(Tips:="Enter currency used in contract")>
        Public Property Currency() As String
            Get
                Return _currency
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Currency", True)
                If value Is Nothing Then value = String.Empty
                If Not _currency.Equals(value) Then
                    _currency = value
                    PropertyHasChanged("Currency")
                End If
            End Set
        End Property

        Private _contractValue As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(Tips:="Enter value of Contract")>
        Public Property ContractValue() As String
            Get
                Return _contractValue.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ContractValue", True)
                If value Is Nothing Then value = String.Empty
                If Not _contractValue.Equals(value) Then
                    _contractValue.Text = value
                    PropertyHasChanged("ContractValue")
                End If
            End Set
        End Property

        Private _vatRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(Tips:="Enter V.A.T tax rate of the contract")>
        Public Property VatRate() As String
            Get
                Return _vatRate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("VatRate", True)
                If value Is Nothing Then value = String.Empty
                If Not _vatRate.Equals(value) Then
                    _vatRate.Text = value
                    PropertyHasChanged("VatRate")
                End If
            End Set
        End Property

        Private _vatAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(Tips:="Enter amount of money equivalent with VAT tax rate")>
        Public Property VatAmount() As String
            Get
                Return _vatAmount.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("VatAmount", True)
                If value Is Nothing Then value = String.Empty
                If Not _vatAmount.Equals(value) Then
                    _vatAmount.Text = value
                    PropertyHasChanged("VatAmount")
                End If
            End Set
        End Property

        Private _retentionRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(Tips:="Enter retention rate of contructions")>
        Public Property RetentionRate() As String
            Get
                Return _retentionRate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("RetentionRate", True)
                If value Is Nothing Then value = String.Empty
                If Not _retentionRate.Equals(value) Then
                    _retentionRate.Text = value
                    PropertyHasChanged("RetentionRate")
                End If
            End Set
        End Property

        Private _retentionAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(Tips:="Enter amount of money equivalent with retention rate")>
        Public Property RetentionAmount() As String
            Get
                Return _retentionAmount.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("RetentionAmount", True)
                If value Is Nothing Then value = String.Empty
                If Not _retentionAmount.Equals(value) Then
                    _retentionAmount.Text = value
                    PropertyHasChanged("RetentionAmount")
                End If
            End Set
        End Property

        Private _projectCode As String = String.Empty
        <CellInfo(Tips:="Enter project code")>
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

        Private _performanceSecurityRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(Tips:="Enter performance security rate")>
        Public Property PerformanceSecurityRate() As String
            Get
                Return _performanceSecurityRate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PerformanceSecurityRate", True)
                If value Is Nothing Then value = String.Empty
                If Not _performanceSecurityRate.Equals(value) Then
                    _performanceSecurityRate.Text = value
                    PropertyHasChanged("PerformanceSecurityRate")
                End If
            End Set
        End Property

        Private _performanceSecurityAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(Tips:="Enter amount of money equivalent with performance security rate")>
        Public Property PerformanceSecurityAmount() As String
            Get
                Return _performanceSecurityAmount.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PerformanceSecurityAmount", True)
                If value Is Nothing Then value = String.Empty
                If Not _performanceSecurityAmount.Equals(value) Then
                    _performanceSecurityAmount.Text = value
                    PropertyHasChanged("PerformanceSecurityAmount")
                End If
            End Set
        End Property

        Private _validTo As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(Tips:="Enter date that performance security will expired")>
        Public Property ValidTo() As String
            Get
                Return _validTo.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ValidTo", True)
                If value Is Nothing Then value = String.Empty
                If Not _validTo.Equals(value) Then
                    _validTo.Text = value
                    PropertyHasChanged("ValidTo")
                End If
            End Set
        End Property

        Private _performFrom As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(Tips:="Perform from date")>
        Public Property PerformFrom() As String
            Get
                Return _performFrom.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PerformFrom", True)
                If value Is Nothing Then value = String.Empty
                If Not _performFrom.Equals(value) Then
                    _performFrom.Text = value
                    PropertyHasChanged("PerformFrom")
                End If
            End Set
        End Property

        Private _perfromTo As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(Tips:="Perform to date ")>
        Public Property PerfromTo() As String
            Get
                Return _perfromTo.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PerfromTo", True)
                If value Is Nothing Then value = String.Empty
                If Not _perfromTo.Equals(value) Then
                    _perfromTo.Text = value
                    PropertyHasChanged("PerfromTo")
                End If
            End Set
        End Property

        Private _contractContents As String = String.Empty
        <CellInfo(Tips:="Enter Contents of contract", ControlType:=Forms.CtrlType.MemoEdit)>
        Public Property ContractContents() As String
            Get
                Return _contractContents
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ContractContents", True)
                If value Is Nothing Then value = String.Empty
                If Not _contractContents.Equals(value) Then
                    _contractContents = value
                    PropertyHasChanged("ContractContents")
                End If
            End Set
        End Property

        Private _processingRequest As String = String.Empty
        <CellInfo(Tips:="Enter Requirement about processing of constructions", ControlType:=Forms.CtrlType.MemoEdit)>
        Public Property ProcessingRequest() As String
            Get
                Return _processingRequest
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ProcessingRequest", True)
                If value Is Nothing Then value = String.Empty
                If Not _processingRequest.Equals(value) Then
                    _processingRequest = value
                    PropertyHasChanged("ProcessingRequest")
                End If
            End Set
        End Property

        Private _paymentTerms As String = String.Empty
        <CellInfo(Tips:="Enter Terms to get payment")>
        Public Property PaymentTerms() As String
            Get
                Return _paymentTerms
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PaymentTerms", True)
                If value Is Nothing Then value = String.Empty
                If Not _paymentTerms.Equals(value) Then
                    _paymentTerms = value
                    PropertyHasChanged("PaymentTerms")
                End If
            End Set
        End Property

        Private _comments As String = String.Empty
        <CellInfo(Tips:="Enter contents to be noted")>
        Public Property Comments() As String
            Get
                Return _comments
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Comments", True)
                If value Is Nothing Then value = String.Empty
                If Not _comments.Equals(value) Then
                    _comments = value
                    PropertyHasChanged("Comments")
                End If
            End Set
        End Property

        Private _appendix As String = String.Empty
        <CellInfo(Tips:="Enter appendix code")>
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
            'ValidationRules.AddDependantProperty("AcCTRCode", "AnalT0")
        End Sub

        Protected Overrides Sub AddBusinessRules()
            AddSharedCommonRules()

            For Each _field As ClassField In ClassSchema(Of CTR)._fieldList
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
            Rules.BusinessRules.RegisterBusinessRules(Me)
            MyBase.AddBusinessRules()
        End Sub
#End Region ' Validation

#Region " Factory Methods "

        Private Sub New()
            _DTB = Context.CurrentBECode
        End Sub

        Public Shared Function BlankCTR() As CTR
            Return New CTR
        End Function

        Public Shared Function NewCTR(ByVal pLineNo As String) As CTR
            'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("CTR")))
            Return DataPortal.Create(Of CTR)(New Criteria(pLineNo.ToInteger))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As CTR
            Dim pLineNo As String = ID.Trim

            Return NewCTR(pLineNo)
        End Function

        Public Shared Function GetCTR(ByVal pLineNo As String) As CTR
            Return DataPortal.Fetch(Of CTR)(New Criteria(pLineNo))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As CTR
            Dim pLineNo As String = ID.Trim

            Return GetCTR(pLineNo)
        End Function

        Public Shared Sub DeleteCTR(ByVal pLineNo As String)
            DataPortal.Delete(New Criteria(pLineNo.ToInteger))
        End Sub

        Public Overrides Function Save() As CTR
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("CTR")))

            Me.ApplyEdit()
            CTRInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneCTR(ByVal pLineNo As String) As CTR

            'If CTR.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningCTR As CTR = MyBase.Clone
            cloningCTR._lineNo = 0
            cloningCTR._DTB = Context.CurrentBECode

            'Todo:Remember to reset status of the new object here 
            cloningCTR.MarkNew()
            cloningCTR.ApplyEdit()

            cloningCTR.ValidationRules.CheckRules()

            Return cloningCTR
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
                    cm.CommandText = <SqlText>SELECT * FROM pbs_PM_CONTRACT_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim

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
            _contractDate.Text = dr.GetInt32("CONTRACT_DATE")
            _contractor = dr.GetString("CONTRACTOR").TrimEnd
            _contructionUnit = dr.GetString("CONTRUCTION_UNIT").TrimEnd
            _contructionUnitName = dr.GetString("CONTRUCTION_UNIT_NAME").TrimEnd
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
            _perfromTo.Text = dr.GetInt32("PERFROM_TO")
            _contractContents = dr.GetString("CONTRACT_CONTENTS").TrimEnd
            _processingRequest = dr.GetString("PROCESSING_REQUEST").TrimEnd
            _paymentTerms = dr.GetString("PAYMENT_TERMS").TrimEnd
            _comments = dr.GetString("COMMENTS").TrimEnd
            _appendix = dr.GetString("APPENDIX").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_PM_CONTRACT_{0}_Insert", _DTB)

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
            cm.Parameters.AddWithValue("@CONTRACT_DATE", _contractDate.DBValue)
            cm.Parameters.AddWithValue("@CONTRACTOR", _contractor.Trim)
            cm.Parameters.AddWithValue("@CONTRUCTION_UNIT", _contructionUnit.Trim)
            cm.Parameters.AddWithValue("@CONTRUCTION_UNIT_NAME", _contructionUnitName.Trim)
            cm.Parameters.AddWithValue("@CONTRACT_TYPE", _contractType.Trim)
            cm.Parameters.AddWithValue("@CONTRACT_FORM", _contractForm.Trim)
            cm.Parameters.AddWithValue("@CURRENCY", _currency.Trim)
            cm.Parameters.AddWithValue("@CONTRACT_VALUE", _contractValue.DBValue)
            cm.Parameters.AddWithValue("@VAT_RATE", _vatRate.DBValue)
            cm.Parameters.AddWithValue("@VAT_AMOUNT", _vatAmount.DBValue)
            cm.Parameters.AddWithValue("@RETENTION_RATE", _retentionRate.DBValue)
            cm.Parameters.AddWithValue("@RETENTION_AMOUNT", _retentionAmount.DBValue)
            cm.Parameters.AddWithValue("@PROJECT_CODE", _projectCode.Trim)
            cm.Parameters.AddWithValue("@PERFORMANCE_SECURITY_RATE", _performanceSecurityRate.DBValue)
            cm.Parameters.AddWithValue("@PERFORMANCE_SECURITY_AMOUNT", _performanceSecurityAmount.DBValue)
            cm.Parameters.AddWithValue("@VALID_TO", _validTo.DBValue)
            cm.Parameters.AddWithValue("@PERFORM_FROM", _performFrom.DBValue)
            cm.Parameters.AddWithValue("@PERFROM_TO", _perfromTo.DBValue)
            cm.Parameters.AddWithValue("@CONTRACT_CONTENTS", _contractContents.Trim)
            cm.Parameters.AddWithValue("@PROCESSING_REQUEST", _processingRequest.Trim)
            cm.Parameters.AddWithValue("@PAYMENT_TERMS", _paymentTerms.Trim)
            cm.Parameters.AddWithValue("@COMMENTS", _comments.Trim)
            cm.Parameters.AddWithValue("@APPENDIX", _appendix.Trim)
            cm.Parameters.AddWithValue("@UPDATED", ToDay.ToSunDate)
            cm.Parameters.AddWithValue("@UPDATED_BY", Context.CurrentUserCode)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_PM_CONTRACT_{0}_Update", _DTB)

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
                    cm.CommandText = <SqlText>DELETE pbs_PM_CONTRACT_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
        '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
        '        CTRInfoList.InvalidateCache()
        '    End If
        'End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pLineNo As String) As Boolean
            Return CTRInfoList.ContainsCode(pLineNo)
        End Function

        'Public Shared Function KeyDuplicated(ByVal pLineNo As SmartInt32) As Boolean
        '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_PM_CONTRACT_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
        '    Return SQLCommander.GetScalarInteger(SqlText) > 0
        'End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneCTR(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(CTR).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(CTR).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return CTRInfoList.GetCTRInfoList
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

End Namespace