﻿using System;
namespace OneToMany_task.ViewModels
{
	public class HeaderVM
	{
		public Dictionary<string,string> Settings { get; set; }
		public int BasketCount { get; set; }
		public decimal BasketTotalPrice { get; set; }
	}
}

