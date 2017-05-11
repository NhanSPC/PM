
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

'Namespace PM

<Serializable()> _
Public Class PROGRESSInfo
    Inherits Csla.ReadOnlyBase(Of PROGRESSInfo)
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

    Private _appendix As String = String.Empty
    Public ReadOnly Property Appendix() As String
        Get
            Return _appendix
        End Get
    End Property

    Private _projectCode As String = String.Empty
    Public ReadOnly Property ProjectCode() As String
        Get
            Return _projectCode
        End Get
    End Property

    Private _stageNo As String = String.Empty
    Public ReadOnly Property StageNo() As String
        Get
            Return _stageNo
        End Get
    End Property

    Private _wbsCode As String = String.Empty
    Public ReadOnly Property WbsCode() As String
        Get
            Return _wbsCode
        End Get
    End Property

    Private _inspectionDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
    Public ReadOnly Property InspectionDate() As String
        Get
            Return _inspectionDate.DateViewFormat
        End Get
    End Property

    Private _inspectionTime As pbs.Helper.SmartTime = New pbs.Helper.SmartTime()
    Public ReadOnly Property InspectionTime() As String
        Get
            Return _inspectionTime.Text
        End Get
    End Property

    Private _completedJobProrate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property CompletedJobProrate() As String
        Get
            Return _completedJobProrate.Text
        End Get
    End Property

    Private _completedJob As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
    Public ReadOnly Property CompletedJob() As String
        Get
            Return _completedJob.Text
        End Get
    End Property

    Private _documentation As String = String.Empty
    Public ReadOnly Property Documentation() As String
        Get
            Return _documentation
        End Get
    End Property

    Private _jobQualityComment As String = String.Empty
    Public ReadOnly Property JobQualityComment() As String
        Get
            Return _jobQualityComment
        End Get
    End Property

    Private _result As String = String.Empty
    Public ReadOnly Property Result() As String
        Get
            Return _result
        End Get
    End Property

    Private _notes As String = String.Empty
    Public ReadOnly Property Notes() As String
        Get
            Return _notes
        End Get
    End Property

    Private _investor As String = String.Empty
    Public ReadOnly Property Investor() As String
        Get
            Return _investor
        End Get
    End Property

    Private _contractor As String = String.Empty
    Public ReadOnly Property Contractor() As String
        Get
            Return _contractor
        End Get
    End Property

    Private _constructionUnit As String = String.Empty
    Public ReadOnly Property ConstructionUnit() As String
        Get
            Return _constructionUnit
        End Get
    End Property

    Private _otherParties As String = String.Empty
    Public ReadOnly Property OtherParties() As String
        Get
            Return _otherParties
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
            Return String.Format("WBS: {0}, Contract: {1}", _wbsCode, _contractNo)
        End Get
    End Property


    Public Sub InvalidateCache() Implements IInfo.InvalidateCache
        PROGRESSInfoList.InvalidateCache()
    End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

    Friend Shared Function GetPROGRESSInfo(ByVal dr As SafeDataReader) As PROGRESSInfo
        Return New PROGRESSInfo(dr)
    End Function

    Friend Shared Function EmptyPROGRESSInfo(Optional ByVal pLineNo As String = "") As PROGRESSInfo
        Dim info As PROGRESSInfo = New PROGRESSInfo
        With info
            ._lineNo = pLineNo.ToInteger

        End With
        Return info
    End Function

    Private Sub New(ByVal dr As SafeDataReader)
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