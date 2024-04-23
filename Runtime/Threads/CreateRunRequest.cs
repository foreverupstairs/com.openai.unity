// Licensed under the MIT License. See LICENSE in the project root for license information.

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;

namespace OpenAI.Threads
{
    [Preserve]
    public sealed class CreateRunRequest
    {
        [Preserve]
        public CreateRunRequest(string assistantId, CreateRunRequest request)
            : this(assistantId, request?.Model, request?.Instructions, request?.Tools, request?.Metadata, request?.Temperature)
        {
        }

        [Preserve]
        public CreateRunRequest(string assistantId, string model = null, string instructions = null, IEnumerable<Tool> tools = null, IReadOnlyDictionary<string, string> metadata = null, float? temperature = null)
        {
            AssistantId = assistantId;
            Model = model;
            Instructions = instructions;
            Tools = tools?.ToList();
            Metadata = metadata;
            Temperature = temperature;
        }

        /// <summary>
        /// The ID of the assistant used for execution of this run.
        /// </summary>
        [Preserve]
        [JsonProperty("assistant_id")]
        public string AssistantId { get; }

        /// <summary>
        /// The model that the assistant used for this run.
        /// </summary>
        [Preserve]
        [JsonProperty("model")]
        public string Model { get; }

        /// <summary>
        /// The instructions that the assistant used for this run.
        /// </summary>
        [Preserve]
        [JsonProperty("instructions")]
        public string Instructions { get; }

        /// <summary>
        /// The list of tools that the assistant used for this run.
        /// </summary>
        [Preserve]
        [JsonProperty("tools")]
        public IReadOnlyList<Tool> Tools { get; }

        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object.
        /// This can be useful for storing additional information about the object in a structured format.
        /// Keys can be a maximum of 64 characters long and values can be a maximum of 512 characters long.
        /// </summary>
        [Preserve]
        [JsonProperty("metadata")]
        public IReadOnlyDictionary<string, string> Metadata { get; }

        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        /// When null the default temperature (1) will be used.
        /// </summary>
        [Preserve]
        [JsonProperty("temperature")]
        public float? Temperature { get; }
    }
}
