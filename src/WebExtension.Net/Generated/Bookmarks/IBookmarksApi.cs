using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtension.Net.Bookmarks
{
    /// <summary>Use the <c>browser.bookmarks</c> API to create, organize, and otherwise manipulate bookmarks. Also see $(topic:override)[Override Pages], which you can use to create a custom Bookmark Manager page.</summary>
    public interface IBookmarksApi
    {
        /// <summary>Creates a bookmark or folder under the specified parentId.  If url is NULL or missing, it will be a folder.</summary>
        /// <param name="bookmark"></param>
        /// <returns></returns>
        ValueTask<BookmarkTreeNode> Create(CreateDetails bookmark);

        /// <summary>Retrieves the specified BookmarkTreeNode(s).</summary>
        /// <param name="idOrIdList">A single string-valued id, or an array of string-valued ids</param>
        /// <returns></returns>
        ValueTask<IEnumerable<BookmarkTreeNode>> Get(string idOrIdList);

        /// <summary>Retrieves the specified BookmarkTreeNode(s).</summary>
        /// <param name="idOrIdList">A single string-valued id, or an array of string-valued ids</param>
        /// <returns></returns>
        ValueTask<IEnumerable<BookmarkTreeNode>> Get(IEnumerable<string> idOrIdList);

        /// <summary>Retrieves the children of the specified BookmarkTreeNode id.</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<BookmarkTreeNode>> GetChildren(string id);

        /// <summary>Retrieves the recently added bookmarks.</summary>
        /// <param name="numberOfItems">The maximum number of items to return.</param>
        /// <returns></returns>
        ValueTask<IEnumerable<BookmarkTreeNode>> GetRecent(int numberOfItems);

        /// <summary>Retrieves part of the Bookmarks hierarchy, starting at the specified node.</summary>
        /// <param name="id">The ID of the root of the subtree to retrieve.</param>
        /// <returns></returns>
        ValueTask<IEnumerable<BookmarkTreeNode>> GetSubTree(string id);

        /// <summary>Retrieves the entire Bookmarks hierarchy.</summary>
        /// <returns></returns>
        ValueTask<IEnumerable<BookmarkTreeNode>> GetTree();

        /// <summary>Moves the specified BookmarkTreeNode to the provided location.</summary>
        /// <param name="id"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        ValueTask<BookmarkTreeNode> Move(string id, object destination);

        /// <summary>Removes a bookmark or an empty bookmark folder.</summary>
        /// <param name="id"></param>
        ValueTask Remove(string id);

        /// <summary>Recursively removes a bookmark folder.</summary>
        /// <param name="id"></param>
        ValueTask RemoveTree(string id);

        /// <summary>Searches for BookmarkTreeNodes matching the given query. Queries specified with an object produce BookmarkTreeNodes matching all specified properties.</summary>
        /// <param name="query">Either a string of words that are matched against bookmark URLs and titles, or an object. If an object, the properties <c>query</c>, <c>url</c>, and <c>title</c> may be specified and bookmarks matching all specified properties will be produced.</param>
        /// <returns></returns>
        ValueTask<IEnumerable<BookmarkTreeNode>> Search(string query);

        /// <summary>Searches for BookmarkTreeNodes matching the given query. Queries specified with an object produce BookmarkTreeNodes matching all specified properties.</summary>
        /// <param name="query">Either a string of words that are matched against bookmark URLs and titles, or an object. If an object, the properties <c>query</c>, <c>url</c>, and <c>title</c> may be specified and bookmarks matching all specified properties will be produced.</param>
        /// <returns></returns>
        ValueTask<IEnumerable<BookmarkTreeNode>> Search(object query);

        /// <summary>Updates the properties of a bookmark or folder. Specify only the properties that you want to change; unspecified properties will be left unchanged.  'b'Note:'/b' Currently, only 'title' and 'url' are supported.</summary>
        /// <param name="id"></param>
        /// <param name="changes"></param>
        /// <returns></returns>
        ValueTask<BookmarkTreeNode> Update(string id, object changes);
    }
}
