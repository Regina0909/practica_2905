Public Class ServicioEntidad

    Private _servicioID As Integer
    Private _nombreServicio As String
    Private _costoServicio As Decimal
    Private _deleted As Boolean


    Public Property ServicioID As Integer
        Get
            Return _servicioID

        End Get
        Set(value As Integer)
            _servicioID = value

        End Set
    End Property

    Public Property NombreServicio As String
        Get
            Return _nombreServicio

        End Get
        Set(value As String)
            _nombreServicio = value

        End Set
    End Property

    Public Property CostoServicio As Decimal
        Get
            Return _costoServicio

        End Get
        Set(value As Decimal)
            _costoServicio = value

        End Set
    End Property

    Public Property Deleted As Boolean
        Get
            Return _deleted

        End Get
        Set(value As Boolean)
            _deleted = value

        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(servicioID As Integer, nombreServicio As String, costoServicio As Decimal, deleted As Boolean)
        Me.ServicioID = servicioID
        Me.NombreServicio = nombreServicio
        Me.CostoServicio = costoServicio
        Me.Deleted = deleted
    End Sub

End Class
