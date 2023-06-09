﻿using WeAreDotNet.MobileApp.Views;

namespace WeAreDotNet.MobileApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("profile", typeof(ProfilePage));
        Routing.RegisterRoute("members", typeof(MembersOverviewPage));
        Routing.RegisterRoute("creators", typeof(CreatorsOverviewPage));
    }
}

