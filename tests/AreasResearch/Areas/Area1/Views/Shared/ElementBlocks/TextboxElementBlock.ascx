<%--
    ====================================
    Version: 4.19.0.0 Modified: 20181010
    ====================================
--%>

<%@ import namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ import namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ control language="C#" inherits="ViewUserControl<TextboxElementBlock>" %>

<%
    var formElement = Model.FormElement;
    var labelText = Model.Label;
%>

<% using(Html.BeginElement(Model, new { @class="FormTextbox" + Model.GetValidationCssClasses(), data_f_type="textbox" })) { %>
    <div style="background-color: pink">
    <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
    <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="text" class="FormTextbox__Input"
        placeholder="<%: Model.PlaceHolder %>" value="<%: Model.GetDefaultValue() %>" <%= Model.AttributesString %> data-f-datainput />

    <%= Html.ValidationMessageFor(Model) %>
    <%= Model.RenderDataList() %>
    </div>
<% } %>