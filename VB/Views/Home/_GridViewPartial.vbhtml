@Code
    Dim grid = Html.DevExpress().GridView( _
        Sub(settings)
                settings.Name = "GridView"
                settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

                settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Home", .Action = "GridViewPartialAddNew"}
                settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "GridViewPartialUpdate"}
                settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Home", .Action = "GridViewPartialDelete"}
                settings.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow
                settings.SettingsBehavior.ConfirmDelete = True

                settings.CommandColumn.Visible = True
                settings.CommandColumn.ShowNewButton = True
                settings.CommandColumn.ShowDeleteButton = True
                settings.CommandColumn.ShowEditButton = True

                settings.KeyFieldName = "ModelID"
                settings.SetEditFormTemplateContent( _
                    Sub(c)
                            Dim editItem As MVCxGridViewDataBinding.Models.MyModel
                            If (c.Grid.IsNewRowEditing) Then
                                editItem = If(ViewData("Item") IsNot Nothing, CType(ViewData("Item"), MVCxGridViewDataBinding.Models.MyModel), New MVCxGridViewDataBinding.Models.MyModel()
                            Else
                                editItem = If(ViewData("Item") IsNot Nothing, CType(ViewData("Item"), MVCxGridViewDataBinding.Models.MyModel), CType(c.Grid.GetRow(c.VisibleIndex), MVCxGridViewDataBinding.Models.MyModel))
                            End If
                            Html.RenderPartial("_FormLayoutPartial", editItem)
                            Html.DevExpress().Button( _
                               Sub(btnSettings)
                                   btnSettings.Name = "btnUpdate"
                                   btnSettings.UseSubmitBehavior = False
                                   btnSettings.Text = "Update"
                                   btnSettings.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.UpdateEdit(); }}", settings.Name)
                           End Sub).Render()
                            Html.DevExpress().Button( _
                                Sub(btnSettings)
                                    btnSettings.Name = "btnCancel"
                                    btnSettings.UseSubmitBehavior = False
                                    btnSettings.Text = "Cancel"
                                    btnSettings.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.CancelEdit(); }}", settings.Name)
                            End Sub).Render()
                    End Sub)
                settings.SettingsPager.Visible = True
                settings.Settings.ShowGroupPanel = True
                settings.Settings.ShowFilterRow = True
                settings.SettingsBehavior.AllowSelectByRowClick = False
                settings.Columns.Add("ModelID")
                settings.Columns.Add("ModelName")
                settings.Columns.Add("ModelState")
                settings.Columns.Add("ModelDate")
        End Sub)
    If (ViewData("EditError") IsNot Nothing) Then
        grid.SetEditErrorText(ViewData("EditError"))
    End If

End Code

@grid.Bind(Model).GetHtml()