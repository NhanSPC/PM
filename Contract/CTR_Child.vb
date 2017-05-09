Imports pbs.BO.DataAnnotations

Namespace PM

    Partial Class CTR

        <System.ComponentModel.Browsable(False)>
        Public Overrides ReadOnly Property IsDirty As Boolean
            Get
                Return MyBase.IsDirty OrElse Details.IsDirty
            End Get
        End Property

        <System.ComponentModel.Browsable(False)>
        Public Overrides ReadOnly Property IsValid As Boolean
            Get
                Return MyBase.IsValid AndAlso Details.IsValid
            End Get
        End Property

        Private _details As WBSs = Nothing

        <TableRangeInfo()>
        ReadOnly Property Details As WBSs
            Get
                If _details Is Nothing Then
                    _details = WBSs.NewWBSs(Me)
                End If
                Return _details
            End Get
        End Property


    End Class

End Namespace
