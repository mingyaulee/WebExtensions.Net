using JsBind.Net;
using System;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class Colors : BaseObject
{
    /// <summary></summary>
    [Obsolete("Unsupported colors property, use 'theme.colors.frame', this alias is ignored in Firefox >= 70.")]
    [JsAccessPath("accentcolor")]
    [JsonPropertyName("accentcolor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Accentcolor { get; set; }

    /// <summary></summary>
    [JsAccessPath("bookmark_text")]
    [JsonPropertyName("bookmark_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Bookmark_text { get; set; }

    /// <summary></summary>
    [JsAccessPath("button_background_active")]
    [JsonPropertyName("button_background_active")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Button_background_active { get; set; }

    /// <summary></summary>
    [JsAccessPath("button_background_hover")]
    [JsonPropertyName("button_background_hover")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Button_background_hover { get; set; }

    /// <summary></summary>
    [JsAccessPath("frame")]
    [JsonPropertyName("frame")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Frame { get; set; }

    /// <summary></summary>
    [JsAccessPath("frame_inactive")]
    [JsonPropertyName("frame_inactive")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Frame_inactive { get; set; }

    /// <summary></summary>
    [JsAccessPath("icons")]
    [JsonPropertyName("icons")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Icons { get; set; }

    /// <summary></summary>
    [JsAccessPath("icons_attention")]
    [JsonPropertyName("icons_attention")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Icons_attention { get; set; }

    /// <summary></summary>
    [JsAccessPath("ntp_background")]
    [JsonPropertyName("ntp_background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Ntp_background { get; set; }

    /// <summary></summary>
    [JsAccessPath("ntp_card_background")]
    [JsonPropertyName("ntp_card_background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Ntp_card_background { get; set; }

    /// <summary></summary>
    [JsAccessPath("ntp_text")]
    [JsonPropertyName("ntp_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Ntp_text { get; set; }

    /// <summary></summary>
    [JsAccessPath("popup")]
    [JsonPropertyName("popup")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Popup { get; set; }

    /// <summary></summary>
    [JsAccessPath("popup_border")]
    [JsonPropertyName("popup_border")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Popup_border { get; set; }

    /// <summary></summary>
    [JsAccessPath("popup_highlight")]
    [JsonPropertyName("popup_highlight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Popup_highlight { get; set; }

    /// <summary></summary>
    [JsAccessPath("popup_highlight_text")]
    [JsonPropertyName("popup_highlight_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Popup_highlight_text { get; set; }

    /// <summary></summary>
    [JsAccessPath("popup_text")]
    [JsonPropertyName("popup_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Popup_text { get; set; }

    /// <summary></summary>
    [JsAccessPath("sidebar")]
    [JsonPropertyName("sidebar")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Sidebar { get; set; }

    /// <summary></summary>
    [JsAccessPath("sidebar_border")]
    [JsonPropertyName("sidebar_border")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Sidebar_border { get; set; }

    /// <summary></summary>
    [JsAccessPath("sidebar_highlight")]
    [JsonPropertyName("sidebar_highlight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Sidebar_highlight { get; set; }

    /// <summary></summary>
    [JsAccessPath("sidebar_highlight_text")]
    [JsonPropertyName("sidebar_highlight_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Sidebar_highlight_text { get; set; }

    /// <summary></summary>
    [JsAccessPath("sidebar_text")]
    [JsonPropertyName("sidebar_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Sidebar_text { get; set; }

    /// <summary></summary>
    [JsAccessPath("tab_background_separator")]
    [JsonPropertyName("tab_background_separator")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Tab_background_separator { get; set; }

    /// <summary></summary>
    [JsAccessPath("tab_background_text")]
    [JsonPropertyName("tab_background_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Tab_background_text { get; set; }

    /// <summary></summary>
    [JsAccessPath("tab_line")]
    [JsonPropertyName("tab_line")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Tab_line { get; set; }

    /// <summary></summary>
    [JsAccessPath("tab_loading")]
    [JsonPropertyName("tab_loading")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Tab_loading { get; set; }

    /// <summary></summary>
    [JsAccessPath("tab_selected")]
    [JsonPropertyName("tab_selected")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Tab_selected { get; set; }

    /// <summary></summary>
    [JsAccessPath("tab_text")]
    [JsonPropertyName("tab_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Tab_text { get; set; }

    /// <summary></summary>
    [Obsolete("Unsupported color property, use 'theme.colors.tab_background_text', this alias is ignored in Firefox >= 70.")]
    [JsAccessPath("textcolor")]
    [JsonPropertyName("textcolor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Textcolor { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar")]
    [JsonPropertyName("toolbar")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar_bottom_separator")]
    [JsonPropertyName("toolbar_bottom_separator")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_bottom_separator { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar_field")]
    [JsonPropertyName("toolbar_field")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_field { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar_field_border")]
    [JsonPropertyName("toolbar_field_border")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_field_border { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar_field_border_focus")]
    [JsonPropertyName("toolbar_field_border_focus")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_field_border_focus { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar_field_focus")]
    [JsonPropertyName("toolbar_field_focus")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_field_focus { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar_field_highlight")]
    [JsonPropertyName("toolbar_field_highlight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_field_highlight { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar_field_highlight_text")]
    [JsonPropertyName("toolbar_field_highlight_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_field_highlight_text { get; set; }

    /// <summary></summary>
    [Obsolete("This color property is ignored in Firefox >= 89.")]
    [JsAccessPath("toolbar_field_separator")]
    [JsonPropertyName("toolbar_field_separator")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_field_separator { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar_field_text")]
    [JsonPropertyName("toolbar_field_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_field_text { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar_field_text_focus")]
    [JsonPropertyName("toolbar_field_text_focus")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_field_text_focus { get; set; }

    /// <summary>This color property is an alias of 'bookmark_text'.</summary>
    [JsAccessPath("toolbar_text")]
    [JsonPropertyName("toolbar_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_text { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar_top_separator")]
    [JsonPropertyName("toolbar_top_separator")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_top_separator { get; set; }

    /// <summary></summary>
    [JsAccessPath("toolbar_vertical_separator")]
    [JsonPropertyName("toolbar_vertical_separator")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThemeColor Toolbar_vertical_separator { get; set; }
}
