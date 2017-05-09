Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports pbs.Helper

Namespace PM

    <Serializable()> _
    Public Class WBSs
        Inherits Csla.BusinessListBase(Of WBSs, WBS)

#Region " Business Methods"
        Friend _parent As CTR = Nothing

        Protected Overrides Function AddNewCore() As Object
            If _parent IsNot Nothing Then
                Dim theNewLine = WBS.NewWBS(_parent.ContractNo)
                AddNewLine(theNewLine)
                theNewLine.CheckRules()
                Return theNewLine
            Else
                Return MyBase.AddNewCore
            End If
        End Function

        Friend Sub AddNewLine(ByVal pLine As WBS)
            If pLine Is Nothing Then Exit Sub

            'get the next line number
            Dim nextnumber As Integer = 1
            If Me.Count > 0 Then
                Dim allNumbers = (From line In Me Select line.LineNo).ToList
                nextnumber = allNumbers.Max + 1
            End If

            '_line.{LINE_NO} = String.Format("{0:00000}", nextnumber)
            pLine._lineNo = nextnumber

            'Populate _line with info from parent here

            Me.Add(pLine)

        End Sub

#End Region
#Region " Factory Methods "

        Friend Shared Function NewWBSs(ByVal pParent As CTR) As WBSs
            Return New WBSs(pParent)
        End Function

        Friend Shared Function GetWBSs(ByVal dr As SafeDataReader, ByVal parent As CTR) As WBSs
            Dim ret = New WBSs(dr, parent)
            ret.MarkAsChild()
            Return ret
        End Function

        Private Sub New(ByVal parent As CTR)
            _parent = parent
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As SafeDataReader, ByVal parent As CTR)
            _parent = parent
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region ' Factory Methods
#Region " Data Access "

        Private Sub Fetch(ByVal dr As SafeDataReader)
            RaiseListChangedEvents = False

            'Dim suppressChildValidation = True
            While dr.Read()
                Dim Line = WBS.GetChildWBS(dr)
                Me.Add(Line)
            End While

            RaiseListChangedEvents = True
        End Sub

        Friend Sub Update(ByVal cn As SqlConnection, ByVal parent As CTR)
            RaiseListChangedEvents = False

            ' loop through each deleted child object
            For Each deletedChild As WBS In DeletedList
                deletedChild._DTB = parent._DTB
                deletedChild.DeleteSelf(cn)
            Next
            DeletedList.Clear()

            ' loop through each non-deleted child object
            For Each child As WBS In Me
                child._DTB = parent._DTB
                child.ContractNo = parent.LineNo
                'child.OrderNo = parent.OrderNo
                If child.IsNew Then
                    child.Insert(cn)
                    'child.markold()
                Else
                    child.Update(cn)
                End If

            Next

            RaiseListChangedEvents = True
        End Sub

#End Region ' Data Access                   
    End Class

End Namespace