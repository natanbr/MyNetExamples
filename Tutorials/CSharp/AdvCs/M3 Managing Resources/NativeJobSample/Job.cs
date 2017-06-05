using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Jobs
{
    public class Job : IDisposable
    {
        private readonly List<Process> _processes;
        private IntPtr _hJob;

        public Job(string name)
        {
            _hJob = NativeJob.CreateJobObject(IntPtr.Zero, name);

            if (_hJob == IntPtr.Zero)
                throw new InvalidOperationException("Can't create job!");
            
            _processes = new List<Process>();
        }

        public Job()
            : this(null)
        {
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_hJob == IntPtr.Zero) return;

            Dispose(true);
        }

        #endregion

        protected void AddProcessToJob(IntPtr hProcess)
        {
            CheckIfDisposed();

            if (!NativeJob.AssignProcessToJobObject(_hJob, hProcess))
                throw new InvalidOperationException("Failed to add process to job");
        }

        public void AddProcessToJob(int pid)
        {
            CheckIfDisposed();

            AddProcessToJob(Process.GetProcessById(pid));
        }

        public void AddProcessToJob(Process proc)
        {
            Debug.Assert(proc != null);
            AddProcessToJob(proc.Handle);
            _processes.Add(proc);
        }

        public void Kill()
        {
            CheckIfDisposed();

            var b = NativeJob.TerminateJobObject(_hJob, 0);
        }

        public void Dispose(bool disposing)
        {
            if (_hJob == IntPtr.Zero)
                return;

            if (disposing)
            {
                ReleaseManaged();
                GC.SuppressFinalize(this);
            }

            NativeJob.CloseHandle(_hJob);
            _hJob = IntPtr.Zero;
        }

        private void ReleaseManaged()
        {
            foreach (var p in _processes)
                p.Dispose();
        }

        ~Job()
        {
            Dispose(false);
        }

        protected void CheckIfDisposed()
        {
            if (_hJob == IntPtr.Zero)
                throw new ObjectDisposedException("_hJob");
        }
    }
}