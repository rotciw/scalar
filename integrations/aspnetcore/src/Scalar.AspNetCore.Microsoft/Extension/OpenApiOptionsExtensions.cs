using Microsoft.AspNetCore.OpenApi;

namespace Scalar.AspNetCore;

/// <summary>
/// Scalar extensions for <see cref="OpenApiOptions" />.
/// </summary>
public static class OpenApiOptionsExtensions
{
    /// <summary>
    /// Adds required Scalar transformers to the <see cref="OpenApiOptions" />.
    /// </summary>
    /// <param name="options"><see cref="OpenApiOptions" />.</param>
    public static OpenApiOptions AddScalarTransformers(this OpenApiOptions options)
    {
        options.AddOperationTransformer<StabilityOpenApiOperationTransformer>();
        options.AddOperationTransformer<ExcludeFromApiReferenceOpenApiOperationTransformer>();
        options.AddDocumentTransformer<ExcludeFromApiReferenceOpenApiDocumentTransformer>();

        return options;
    }

    // /// <summary>
    // /// Sets an alternate display name for a given tag.
    // /// </summary>
    // /// <param name="options"><see cref="OpenApiOptions" />.</param>
    // /// <param name="tag">The tag to set the display name for.</param>
    // /// <param name="displayName">The display name to set.</param>
//     public static OpenApiOptions TagDisplayName(this OpenApiOptions options, string tag, string displayName)
//     {
//         options.AddDocumentTransformer((document, _, _) =>
//         {
//             var openApiTag = document.Tags?.FirstOrDefault(t => t.Name == tag);
// #if NET10_0_OR_GREATER
//             var node = SerializeToNode(displayName);
//             openApiTag?.Extensions.TryAdd(DisplayName, new OpenApiAny(node));
// #elif NET9_0
//             openApiTag?.Extensions.TryAdd(DisplayName, new OpenApiString(displayName));
// #endif
//             return Task.CompletedTask;
//         });
//         return options;
//     }

    // /// <summary>
    // /// Groups tags by a given name.
    // /// </summary>
    // /// <param name="options"><see cref="OpenApiOptions" />.</param>
    // /// <param name="name">The name of the group.</param>
    // /// <param name="tags">The tags which should be added to the group.</param>
    // public static OpenApiOptions GroupTags(this OpenApiOptions options, string name, params IEnumerable<string> tags)
    // {
    //     options.AddDocumentTransformer((document, _, _) =>
    //     {
    //         var tagNames = tags.Select(x => new OpenApiString(x));
    //
    //         var tagArray = new OpenApiArray();
    //         tagArray.AddRange(tagNames);
    //         var openApiObject = new OpenApiObject
    //         {
    //             ["name"] = new OpenApiString(name),
    //             ["tags"] = tagArray
    //         };
    //
    //         if (!document.Extensions.TryGetValue(TagGroups, out var existingGroup))
    //         {
    //             existingGroup = new OpenApiArray();
    //             document.Extensions.Add(TagGroups, existingGroup);
    //         }
    //
    //         if (existingGroup is OpenApiArray group)
    //         {
    //             group.Add(openApiObject);
    //         }
    //
    //         return Task.CompletedTask;
    //     });
    //     return options;
    // }
}