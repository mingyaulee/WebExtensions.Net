using System;
using System.Text.Json;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Menus
{
    /// <summary>The part of the menus API that is available in all extension contexts, including content scripts.</summary>
    public partial interface IMenusApi
    {
        /// <summary>The maximum number of top level extension items that can be added to an extension action context menu. Any items beyond this limit will be ignored.</summary>
        int ACTION_MENU_TOP_LEVEL_LIMIT { get; }

        /// <summary>Fired when a context menu item is clicked.</summary>
        OnClickedEvent OnClicked { get; }

        /// <summary>Fired when a menu is hidden. This event is only fired if onShown has fired before.</summary>
        Event OnHidden { get; }

        /// <summary>Fired when a menu is shown. The extension can add, modify or remove menu items and call menus.refresh() to update the menu.</summary>
        OnShownEvent OnShown { get; }

        /// <summary>Creates a new context menu item. Note that if an error occurs during creation, you may not find out until the creation callback fires (the details will be in $(ref:runtime.lastError)).</summary>
        /// <param name="createProperties"></param>
        /// <param name="callback">Called when the item has been created in the browser. If there were any problems creating the item, details will be available in $(ref:runtime.lastError).</param>
        /// <returns>The ID of the newly created item.</returns>
        ValueTask<CreateReturnType> Create(CreateProperties createProperties, Action callback);

        /// <summary>Retrieve the element that was associated with a recent contextmenu event.</summary>
        /// <param name="targetElementId">The identifier of the clicked element, available as info.targetElementId in the menus.onShown, onClicked or onclick event.</param>
        /// <returns></returns>
        ValueTask<JsonElement> GetTargetElement(int targetElementId);

        /// <summary>Show the matching menu items from this extension instead of the default menu. This should be called during a 'contextmenu' DOM event handler, and only applies to the menu that opens after this event.</summary>
        /// <param name="contextOptions"></param>
        ValueTask OverrideContext(ContextOptions contextOptions);

        /// <summary>Updates the extension items in the shown menu, including changes that have been made since the menu was shown. Has no effect if the menu is hidden. Rebuilding a shown menu is an expensive operation, only invoke this method when necessary.</summary>
        ValueTask Refresh();

        /// <summary>Removes a context menu item.</summary>
        /// <param name="menuItemId">The ID of the context menu item to remove.</param>
        ValueTask Remove(int menuItemId);

        /// <summary>Removes a context menu item.</summary>
        /// <param name="menuItemId">The ID of the context menu item to remove.</param>
        ValueTask Remove(string menuItemId);

        /// <summary>Removes all context menu items added by this extension.</summary>
        ValueTask RemoveAll();

        /// <summary>Updates a previously created context menu item.</summary>
        /// <param name="id">The ID of the item to update.</param>
        /// <param name="updateProperties">The properties to update. Accepts the same values as the create function.</param>
        ValueTask Update(int id, UpdateProperties updateProperties);

        /// <summary>Updates a previously created context menu item.</summary>
        /// <param name="id">The ID of the item to update.</param>
        /// <param name="updateProperties">The properties to update. Accepts the same values as the create function.</param>
        ValueTask Update(string id, UpdateProperties updateProperties);
    }
}
