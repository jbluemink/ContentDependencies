using Sitecore.Data.Items;
using Sitecore.Layouts.Models;
using Sitecore.Pipelines.GetRenderingContentDependencies;
using System.Collections.Generic;

namespace ContentDependencies
{
    public class HomeItem
    {
        //see https://doc.sitecore.com/en/developers/101/sitecore-experience-manager/configure-html-caching.html#UUID-bf630a57-97ea-900b-6d62-ad57c7fe83a5_section-idm232136386794561
        public void Process(GetRenderingContentDependenciesArgs args)
        {
            if (args.Datasource == null || args.Datasource.Count == 0 || args.RenderingItem == null)
            {
                return;
            }

            if (args.RenderingItem.ContentDependencies.Contains(new Sitecore.Data.ID("{F717D198-FAC9-45E7-88AF-E48FF11494A0}")))
            {
                var result = new List<ContentDependencyEntry>();

                Item hometitem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
                ContentDependencyEntry entry = new ContentDependencyEntry(hometitem);
                result.Add(entry);

                args.AddResolvedDependencies(result); // submit the result
            }
        }
    }
}
