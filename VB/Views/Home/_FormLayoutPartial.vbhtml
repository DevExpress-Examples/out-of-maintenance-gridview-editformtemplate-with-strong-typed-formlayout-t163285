@ModelType MVCxGridViewDataBinding.Models.MyModel

@Html.DevExpress().FormLayout( _
    Sub(settings)
            settings.Name = "FormLayout"
            Dim addGroupAction As Action(Of DevExpress.Web.Mvc.MVCxFormLayoutGroup(Of MVCxGridViewDataBinding.Models.MyModel)) = _
                Sub(groupSettings)
                        groupSettings.Caption = "ModelGroup"
                        groupSettings.ShowCaption = DefaultBoolean.True
                        groupSettings.GroupBoxDecoration = GroupBoxDecoration.Default
                End Sub
            Dim groupItem As MVCxFormLayoutGroup(Of MVCxGridViewDataBinding.Models.MyModel) = settings.Items.AddGroupItem(addGroupAction)

            groupItem.Items.Add(Function(m) m.ModelName, _
                Sub(s)
                        CType(s.NestedExtensionSettings, TextBoxSettings).ShowModelErrors = True
                End Sub)

            groupItem.Items.Add(Function(m) m.ModelState, _
                Sub(s)
                        CType(s.NestedExtensionSettings, CheckBoxSettings).ShowModelErrors = True
                End Sub)

            groupItem.Items.Add(Function(m) m.ModelDate, _
                Sub(s)
                        CType(s.NestedExtensionSettings, DateEditSettings).ShowModelErrors = True
                End Sub)
    End Sub).GetHtml()
