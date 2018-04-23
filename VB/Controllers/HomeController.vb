Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports MVCxGridViewDataBinding.Models

Namespace Q588216.Controllers
    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View()
        End Function

        Public ReadOnly Property Data() As List(Of MyModel)
            Get
                If TryCast(Session("data"), List(Of MyModel)) Is Nothing Then
                    Session("data") = MyModel.GetModelList()
                End If
                Return TryCast(Session("data"), List(Of MyModel))
            End Get
        End Property

        <ValidateInput(False)>
        Public Function GridViewPartial() As ActionResult
            Return PartialView("_GridViewPartial", Data)
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function GridViewPartialAddNew(ByVal item As MyModel) As ActionResult
            ViewData("Item") = item
            If ModelState.IsValid Then
                Try
                    MyModel.InsertModel(Data, item)
                Catch e As Exception
                    ViewData("EditError") = e.Message
                End Try
            Else
                ViewData("EditError") = "Please, correct all errors."
            End If
            Return PartialView("_GridViewPartial", Data)
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function GridViewPartialUpdate(ByVal item As MyModel) As ActionResult
            ViewData("Item") = item
            If ModelState.IsValid Then
                Try
                    MyModel.UpdateModel(Data, item)
                Catch e As Exception
                    ViewData("EditError") = e.Message
                End Try
            Else
                ViewData("EditError") = "Please, correct all errors."
            End If
            Return PartialView("_GridViewPartial", Data)
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function GridViewPartialDelete(ByVal ModelID As Int32) As ActionResult
            If ModelID >= 0 Then
                Try
                    MyModel.DeleteModel(Data, ModelID)
                Catch e As Exception
                    ViewData("EditError") = e.Message
                End Try
            End If
            Return PartialView("_GridViewPartial", Data)
        End Function
    End Class
End Namespace
