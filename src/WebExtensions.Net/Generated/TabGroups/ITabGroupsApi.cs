using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.TabGroups
{
    /// <summary>Use the browser.tabGroups API to interact with the browser's tab grouping system. You can use this API to modify, and rearrange tab groups.</summary>
    [JsAccessPath("tabGroups")]
    public partial interface ITabGroupsApi
    {
        /// <summary>Fired when a tab group is created.</summary>
        [JsAccessPath("onCreated")]
        OnCreatedEvent OnCreated { get; }

        /// <summary>Fired when a tab group is moved, within a window or to another window.</summary>
        [JsAccessPath("onMoved")]
        OnMovedEvent OnMoved { get; }

        /// <summary>Fired when a tab group is removed.</summary>
        [JsAccessPath("onRemoved")]
        OnRemovedEvent OnRemoved { get; }

        /// <summary>Fired when a tab group is updated.</summary>
        [JsAccessPath("onUpdated")]
        OnUpdatedEvent OnUpdated { get; }

        /// <summary>An ID that represents the absence of a group.</summary>
        [JsAccessPath("TAB_GROUP_ID_NONE")]
        int TAB_GROUP_ID_NONE { get; }

        /// <summary>Retrieves details about the specified group.</summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [JsAccessPath("get")]
        ValueTask<TabGroup> Get(int groupId);

        /// <summary>Move a group within, or to another window.</summary>
        /// <param name="groupId"></param>
        /// <param name="moveProperties"></param>
        /// <returns></returns>
        [JsAccessPath("move")]
        ValueTask<TabGroup> Move(int groupId, MoveProperties moveProperties);

        /// <summary>Return all grups, or find groups with specified properties.</summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        [JsAccessPath("query")]
        ValueTask<IEnumerable<TabGroup>> Query(QueryInfo queryInfo);

        /// <summary>Modifies state of a specified group.</summary>
        /// <param name="groupId"></param>
        /// <param name="updateProperties"></param>
        /// <returns></returns>
        [JsAccessPath("update")]
        ValueTask<TabGroup> Update(int groupId, UpdateProperties updateProperties);
    }
}
