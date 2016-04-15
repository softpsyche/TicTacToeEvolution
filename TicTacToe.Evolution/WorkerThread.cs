using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe.Evolution
{

	public abstract class WorkerThread : IWorkerThread
	{
		ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
		ManualResetEvent _pauseEvent = new ManualResetEvent(true);
		Thread _thread;

		public WorkerThread() { }

		public ThreadState State
		{
			get
			{
				return _thread.ThreadState;
			}
		}

		#region IWorkerThread
		public void Start()
		{
			_thread = new Thread(Run);
			_thread.Start();
			Log("Thread started running");
		}
		public void Pause()
		{
			_pauseEvent.Reset();
			Log("Thread paused");
		}
		public void Resume()
		{
			_pauseEvent.Set();
			Log("Thread resuming ");
		}
		public void Stop()
		{
			// Signal the shutdown event
			_shutdownEvent.Set();
			Log("Thread Stopped ");

			// Make sure to resume any paused threads
			_pauseEvent.Set();

			// Wait for the thread to exit
			_thread.Join();
		}
		#endregion

		private void Run()
		{
			while (true)
			{
				_pauseEvent.WaitOne(Timeout.Infinite);

				if (_shutdownEvent.WaitOne(0))
					break;

				// Do the work..
				Work();

				Log("Thread is running");

			}
		}
		private void Log(String message)
		{
			Console.WriteLine(message);
		}

		protected abstract void Work();
	}

	public interface IWorkerThread
	{
		void Start();
		void Pause();
		void Resume();
		void Stop();
	}
}
