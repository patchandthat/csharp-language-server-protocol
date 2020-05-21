﻿using OmniSharp.Extensions.LanguageServer.Protocol.Workspace;
using OmniSharp.Extensions.LanguageServer.Server;

namespace OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities
{
    public class ExecuteCommandCapability : DynamicCapability, ConnectedCapability<IExecuteCommandHandler> { }
}
