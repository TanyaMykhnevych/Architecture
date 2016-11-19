﻿using System;
using Architecture.Presentation.Views.Architect;
using Architecture.Presentation.Views.Architecture;
using Architecture.Presentation.Views.Restoration;
using Architecture.Presentation.Views.Style;
using Architecture.Presentation.Views.Repair;
using Architecture.Presentation.Views.Source;

namespace Architecture.Presentation.Models
{
    public enum PageKeys
    {
        [PageType(typeof(ArchitecturePage))]
        Architecture,
        [PageType(typeof(ArchitectureMainPage))]
        ArchitectureMain,
        [PageType(typeof(ArchitectureAddPage))]
        ArchitectureAdd,
        [PageType(typeof(ArchitectureReportsPage))]
        ArchitectureReports,
        [PageType(typeof(ArchitectureStatisticsPage))]
        ArchitectureStatistics,
        [PageType(typeof(ArchitectMainPage))]
        ArchitectMain,
        [PageType(typeof(ArchitectSearchPage))]
        ArchitectSearch,
        [PageType(typeof(ArchitectFilterPage))]
        ArchitectFilter,
        [PageType(typeof(ArchitectAddPage))]
        ArchitectAdd,
        [PageType(typeof(ArchitectUpdatePage))]
        ArchitectUpdate,
        [PageType(typeof(StyleMainPage))]
        StyleMain,
        [PageType(typeof(StyleSearchPage))]
        StyleSearch,
        [PageType(typeof(StyleFilterPage))]
        StyleFilter,
        [PageType(typeof(StyleAddPage))]
        StyleAdd,
        [PageType(typeof(StyleUpdatePage))]
        StyleUpdate,
        [PageType(typeof(SourceMainPage))]
        SourceMain,
        [PageType(typeof(SourceSearchPage))]
        SourceSearch,
        [PageType(typeof(SourceFilterPage))]
        SourceFilter,
        [PageType(typeof(SourceAddPage))]
        SourceAdd,
        [PageType(typeof(SourceUpdatePage))]
        SourceUpdate,
        [PageType(typeof(RestorationSearchPage))]
        RestorationSearch,        
        [PageType(typeof(RestorationUpdatePage))]
        RestorationUpdate,
        [PageType(typeof(RepairMainPage))]
        RepairMain,
        [PageType(typeof(RepairSearchPage))]
        RepairSearch,
        [PageType(typeof(RepairFilterPage))]
        RepairFilter,
        [PageType(typeof(RepairAddPage))]
        RepairAdd,
        [PageType(typeof(RepairUpdatePage))]
        RepairUpdate,
        [PageType(typeof(RepairAutomatisationPage))]
        RepairAutomatisation
    }

    public class PageTypeAttribute : Attribute
    {
        public PageTypeAttribute(Type pageType)
        {
            PageType = pageType;
        }

        public Type PageType { get; private set; }
    }
}
