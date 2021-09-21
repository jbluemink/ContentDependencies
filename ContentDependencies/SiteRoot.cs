using Sitecore.Data.Items;
using Sitecore.Layouts.Models;
using Sitecore.Pipelines.GetRenderingContentDependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentDependencies
{
    public class SiteRoot
    {
        //see https://doc.sitecore.com/en/developers/101/sitecore-experience-manager/configure-html-caching.html#UUID-bf630a57-97ea-900b-6d62-ad57c7fe83a5_section-idm232136386794561
        public void Process(GetRenderingContentDependenciesArgs args)
        {
            if (args.Datasource == null || args.Datasource.Count == 0 || args.RenderingItem == null)
            {
                return;
            }

            if (args.RenderingItem.ContentDependencies.Contains(new Sitecore.Data.ID("{7DE7D100-0B37-46AA-AE56-01120FC1EE0F}")))
            {
                var result = new List<ContentDependencyEntry>();

                Item rootitem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath);
                ContentDependencyEntry entry = new ContentDependencyEntry(rootitem);
                result.Add(entry);

                args.AddResolvedDependencies(result); // submit the result
            }
        }
    }
}
