﻿using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.TopSites;

/// <summary>Use the chrome.topSites API to access the top sites that are displayed on the new tab page. </summary>
[JsAccessPath("topSites")]
public partial interface ITopSitesApi
{
    /// <summary>Gets a list of top sites.</summary>
    /// <param name="options"></param>
    /// <returns></returns>
    [JsAccessPath("get")]
    ValueTask<IEnumerable<MostVisitedUrl>> Get(Options options = null);
}
