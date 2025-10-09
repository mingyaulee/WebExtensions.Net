using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.TabGroups
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class TabGroupsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "tabGroups")), ITabGroupsApi
    {
        private OnCreatedEvent _onCreated;
        private OnMovedEvent _onMoved;
        private OnRemovedEvent _onRemoved;
        private OnUpdatedEvent _onUpdated;

        /// <inheritdoc />
        public OnCreatedEvent OnCreated
        {
            get
            {
                if (_onCreated is null)
                {
                    _onCreated = new OnCreatedEvent();
                    _onCreated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onCreated"));
                }
                return _onCreated;
            }
        }

        /// <inheritdoc />
        public OnMovedEvent OnMoved
        {
            get
            {
                if (_onMoved is null)
                {
                    _onMoved = new OnMovedEvent();
                    _onMoved.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onMoved"));
                }
                return _onMoved;
            }
        }

        /// <inheritdoc />
        public OnRemovedEvent OnRemoved
        {
            get
            {
                if (_onRemoved is null)
                {
                    _onRemoved = new OnRemovedEvent();
                    _onRemoved.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onRemoved"));
                }
                return _onRemoved;
            }
        }

        /// <inheritdoc />
        public OnUpdatedEvent OnUpdated
        {
            get
            {
                if (_onUpdated is null)
                {
                    _onUpdated = new OnUpdatedEvent();
                    _onUpdated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onUpdated"));
                }
                return _onUpdated;
            }
        }

        /// <inheritdoc />
        public int TAB_GROUP_ID_NONE => -1;

        /// <inheritdoc />
        public virtual ValueTask<TabGroup> Get(int groupId)
            => InvokeAsync<TabGroup>("get", groupId);

        /// <inheritdoc />
        public virtual ValueTask<TabGroup> Move(int groupId, MoveProperties moveProperties)
            => InvokeAsync<TabGroup>("move", groupId, moveProperties);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<TabGroup>> Query(QueryInfo queryInfo)
            => InvokeAsync<IEnumerable<TabGroup>>("query", queryInfo);

        /// <inheritdoc />
        public virtual ValueTask<TabGroup> Update(int groupId, UpdateProperties updateProperties)
            => InvokeAsync<TabGroup>("update", groupId, updateProperties);
    }
}
