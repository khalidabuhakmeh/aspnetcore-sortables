using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Sortables.Models;

/// <summary>
/// Adapted from https://haacked.com/archive/2008/10/23/model-binding-to-a-list.aspx/
/// But this supports any type of index, not just integers
/// </summary>
public static class ListModelBindingExtensions
{
    private static readonly Regex StripIndexerRegex = 
        new(@"\[(?<index>\w+)\]", RegexOptions.Compiled);

    private static string GetIndexerFieldName(this TemplateInfo templateInfo)
    {
        var fieldName = templateInfo.GetFullHtmlFieldName("Index");
        fieldName = StripIndexerRegex.Replace(fieldName, string.Empty);
        if (fieldName.StartsWith("."))
        {
            fieldName = fieldName[1..];
        }

        return fieldName;
    }

    private static object GetIndex(this TemplateInfo templateInfo)
    {
        var fieldName = templateInfo.GetFullHtmlFieldName("Index");
        var match = StripIndexerRegex.Match(fieldName);
        return match.Groups["index"].Value;
    }

    public static HtmlString HiddenIndexerInputForModel<TModel>(this IHtmlHelper<TModel> html)
    {
        var name = html.ViewData.TemplateInfo.GetIndexerFieldName();
        var value = html.ViewData.TemplateInfo.GetIndex();
        var markup = $@"<input type=""hidden"" name=""{name}"" value=""{value}"" />";
        return new HtmlString(markup);
    }
}