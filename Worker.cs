using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace watcher_poc
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;

		public Worker(ILogger<Worker> logger)
		{
			_logger = logger;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{

			FileSystemWatcher watcher = new FileSystemWatcher();
			watcher.Path = @"C:\Users\1149449\data\poc\test";
			watcher.NotifyFilter = NotifyFilters.FileName;
			watcher.Filter = "*.*";


			watcher.Changed += new FileSystemEventHandler(onChange);
			watcher.Deleted += new FileSystemEventHandler(onChange);
			watcher.Created += new FileSystemEventHandler(onChange);

			watcher.EnableRaisingEvents = true;
			while (!stoppingToken.IsCancellationRequested)
			{
				
				await Task.Delay(1000, stoppingToken);



			}
		}

		public void onChange(object sender, FileSystemEventArgs e)
		{
			Console.WriteLine(e.FullPath);

		}
	}
}
