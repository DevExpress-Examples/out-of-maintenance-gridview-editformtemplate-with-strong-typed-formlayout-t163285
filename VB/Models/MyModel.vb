Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Web

Namespace MVCxGridViewDataBinding.Models
	Public Class MyModel
		Public Sub New()
			Me.New(0)
		End Sub

		Public Sub New(ByVal index As Integer)
			ModelID = index
			ModelName = "Name" & index
			ModelState = index Mod 2 = 0
			ModelDate = Date.Now
		End Sub

		Public Property ModelID() As Integer
		<Required>
		Public Property ModelName() As String
		Public Property ModelState() As Boolean?
		Public Property ModelDate() As Date

		Public Shared Function GetModelList() As List(Of MyModel)
			Dim l As New List(Of MyModel)()
			For i As Integer = 0 To 99
				l.Add(New MyModel(i))
			Next i
			Return l
		End Function

		Public Shared Sub UpdateModel(ByVal l As List(Of MyModel), ByVal m As MyModel)
			Dim editedModel As MyModel = l.Where(Function(x) x.ModelID = m.ModelID).First()
			editedModel.ModelName = m.ModelName
			editedModel.ModelDate = m.ModelDate
			editedModel.ModelState = m.ModelState
		End Sub

		Public Shared Sub DeleteModel(ByVal l As List(Of MyModel), ByVal mID As Integer)
			l.Remove(l.Where(Function(x) x.ModelID = mID).First())
		End Sub

		Public Shared Sub InsertModel(ByVal l As List(Of MyModel), ByVal m As MyModel)
			m.ModelID = l.Count + 1
			l.Add(m)
		End Sub
	End Class
End Namespace
