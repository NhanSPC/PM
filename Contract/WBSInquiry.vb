Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports pbs.BO.Script
Imports pbs.BO
Imports pbs.BO.Mail
Imports FlexCel.XlsAdapter


Public Class WBSInquiry
    Implements IQueryBO
    Implements ISupportScripts

#Region "IQueryBO"

    Dim _period As SmartPeriod = New SmartPeriod("T")

    Public Sub AddQueryFilters(pDic As Dictionary(Of String, String)) Implements IQueryBO.AddQueryFilters

    End Sub

    Public ReadOnly Property ChildrenType As Type Implements IQueryBO.ChildrenType
        Get
            Return GetType(WBS)
        End Get
    End Property

    Public Function GetBOList() As IList Implements IQueryBO.GetBOList
        Dim list = (From wbs In WBSInfoList.GetWBSInfoList Where CDate(wbs.PerformFromDate).Month = _period.Period).ToList
        Return list
    End Function

    Public Function GetBOListStatus() As String Implements IQueryBO.GetBOListStatus
        Return "{LineNo}"
    End Function

    Public Function GetDoubleClickCommand() As String Implements IQueryBO.GetDoubleClickCommand
        Return "pbs.BO.PM.WBS?LineNo=[LineNo]&$Action=View"
    End Function

    Public Function GetMyQD() As BO.SQLBuilder.QD Implements IQueryBO.GetMyQD

    End Function

    Public Function GetMyTitle() As String Implements IQueryBO.GetMyTitle
        Return String.Format("WBS in period {0}", _period)
    End Function

    Public Function GetSelectCommand() As String Implements IQueryBO.GetSelectCommand

    End Function

    Public Function GetSelectionChangedCommand() As String Implements IQueryBO.GetSelectionChangedCommand

    End Function

    Public Function GetVariables() As Dictionary(Of String, String) Implements IQueryBO.GetVariables

    End Function

    Public Sub InvalidateCacheList() Implements IQueryBO.InvalidateCacheList

    End Sub

    Public Sub SetParameters(pDic As Dictionary(Of String, String)) Implements IQueryBO.SetParameters

    End Sub

    Public Function Syntax() As String Implements IQueryBO.Syntax
        Return <Syntax>Syntax: pbs.BO.PM.WorkBreakdownStructure?ContractNo=...</Syntax>
    End Function

    Public Sub UpdateCurrentLine(pLine As Object) Implements IQueryBO.UpdateCurrentLine

    End Sub

    Public Sub UpdateQD(pQD As BO.SQLBuilder.QD) Implements IQueryBO.UpdateQD

    End Sub

    Public Sub UpdateSelectedLines(pLines As IEnumerable) Implements IQueryBO.UpdateSelectedLines

    End Sub

    Public Sub ZReset() Implements IQueryBO.ZReset

    End Sub

    Public Function CanExecute(cmd As String) As Boolean? Implements Helper.Interfaces.ISupportCommandAuthorization.CanExecute

    End Function

#End Region

#Region "IsupportScript"

    'Previous button
    Private Function PreviousItem_Imp() As UITasks
        Dim ret = New UITasks(Me)

        ret.IconName = "Prev"
        ret.AddCallMethod(1, "PreviousItem")
        ret.RefreshUIWhenFinish = True

        Return ret
    End Function
    Private Sub PreviousItem()

    End Sub

    'Next button
    Private Function NextItem_Imp() As UITasks
        Dim ret = New UITasks(Me)

        ret.IconName = "Next"
        ret.AddCallMethod(1, "NextItem")
        ret.RefreshUIWhenFinish = True

        Return ret
    End Function
    Private Sub NextItem()

    End Sub

    'Filter button
    Private Function SelectedContract_Imp() As UITasks
        Dim ret = New UITasks(Me)

        ret.IconName = "Find/Find"
        ret.AddCallMethod(1, "SelectedContract")
        ret.RefreshUIWhenFinish = True

        Return ret
    End Function
    Private Sub SelectedContract()
        Dim newPeriod = pbs.Helper.UIServices.ValueSelectorService.SelectValue(LinkCode.Period, ResStr(ResStrConst.SelectItemText("Period")), String.Empty)

        If Not String.IsNullOrEmpty(newPeriod) Then
            _period.Text = newPeriod
        End If

    End Sub




    Public Function GetScriptDictionary() As Dictionary(Of String, UITasks) Implements ISupportScripts.GetScriptDictionary
        Dim ret = New Dictionary(Of String, UITasks)


        ret.Add("Next", NextItem_Imp)
        ret.Add("Filter", SelectedContract_Imp)
        ret.Add("Previous", PreviousItem_Imp)

        Return ret
    End Function
#End Region


End Class
