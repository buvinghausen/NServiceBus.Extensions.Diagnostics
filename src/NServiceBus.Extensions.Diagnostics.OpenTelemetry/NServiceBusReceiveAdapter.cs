﻿using System;
using NServiceBus.Extensions.Diagnostics.OpenTelemetry.Implementation;
using OpenTelemetry.Adapter;
using OpenTelemetry.Trace;

namespace NServiceBus.Extensions.Diagnostics.OpenTelemetry
{
    public class NServiceBusReceiveAdapter : IDisposable
    {
        private readonly DiagnosticSourceSubscriber _diagnosticSourceSubscriber;

        public NServiceBusReceiveAdapter(Tracer tracer)
        {
            _diagnosticSourceSubscriber = new DiagnosticSourceSubscriber(new ProcessMessageListener("NServiceBus.Extensions.Diagnostics.IncomingPhysicalMessage", tracer), null);
            _diagnosticSourceSubscriber.Subscribe();
        }

        public void Dispose()
            => _diagnosticSourceSubscriber?.Dispose();
    }
}
