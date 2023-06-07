Public Class UsuarioEntidad

    Private _usuarioID As Integer
    Private _nombreUsuario As String
    Private _claveUsuario As String


    Public Property UsuarioID As Integer
        Get
            Return _usuarioID

        End Get
        Set(value As Integer)
            _usuarioID = value

        End Set
    End Property

    Public Property NombreUsuario As String
        Get
            Return _nombreUsuario

        End Get
        Set(value As String)
            _nombreUsuario = value

        End Set
    End Property

    Public Property ClaveUsuario As String
        Get
            Return _claveUsuario

        End Get
        Set(value As String)
            _claveUsuario = value

        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(usuarioID As Integer, nombreUsuario As String, claveUsuario As String)
        Me.UsuarioID = usuarioID
        Me.NombreUsuario = nombreUsuario
        Me.ClaveUsuario = claveUsuario
    End Sub

End Class
