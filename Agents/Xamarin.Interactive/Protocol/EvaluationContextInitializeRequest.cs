// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

using Xamarin.Interactive.CodeAnalysis;
using Xamarin.Interactive.Core;

namespace Xamarin.Interactive.Protocol
{
    [Serializable]
    sealed class EvaluationContextInitializeRequest : MainThreadRequest<TargetCompilationConfiguration>
    {
        public TargetCompilationConfiguration Configuration { get; }

        public EvaluationContextInitializeRequest (TargetCompilationConfiguration configuration)
            => Configuration = configuration
                ?? throw new ArgumentNullException (nameof (configuration));

        protected override Task<TargetCompilationConfiguration> HandleAsync (Agent agent)
            => agent.EvaluationContextManager.CreateEvaluationContextAsync (Configuration);
    }
}