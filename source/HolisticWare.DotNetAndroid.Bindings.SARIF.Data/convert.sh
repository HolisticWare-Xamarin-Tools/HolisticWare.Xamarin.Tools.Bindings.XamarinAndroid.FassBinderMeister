#!/bin/bash

quicktype \
    --lang schema \
    --src-lang json \
    --src 20250608/HolisticWare.Google.AutoValue.sarif \
    --out 20250608/HolisticWare.Google.AutoValue.sarif.schema.json \


quicktype \
    --lang csharp \
    --src-lang schema \
    --framework NewtonSoft \
    --namespace HolisticWare.DotNetAndroid.Bindings.SARIF.Generated.NewtonSoft \
    --csharp-version 6 \
    --src 20250608/HolisticWare.Google.AutoValue.sarif.schema.json \
    --out 20250608/HolisticWare.Google.AutoValue.SARIF.NewtonSoft.Generated.cs \


quicktype \
    --lang csharp \
    --src-lang schema \
    --framework SystemTextJson \
    --namespace HolisticWare.DotNetAndroid.Bindings.SARIF.Generated.SystemTextJson \
    --csharp-version 6 \
    --src 20250608/HolisticWare.Google.AutoValue.sarif.schema.json \
    --out 20250608/HolisticWare.Google.AutoValue.SARIF.SystemTextJson.Generated.cs \


# quicktype [--lang LANG] [--src-lang SRC_LANG] [--out FILE] FILE|URL ...     
#                                                                                 
#   LANG ... cs|go|rs|cr|cjson|c++|objc|java|ts|js|javascript-prop-               
#   types|flow|swift|scala3|Smithy|kotlin|elm|schema|ruby|dart|py|pike|haskell|typescript- 
#   zod|typescript-effect-schema|php                                              
#                                                                                 
#   SRC_LANG ... json|schema|graphql|postman|typescript                           
# 
# Description
# 
#   Given JSON sample data, quicktype outputs code for working with that data in  
#   C#, Go, Rust, Crystal, C (cJSON), C++, Objective-C, Java, TypeScript,         
#   JavaScript, JavaScript PropTypes, Flow, Swift, Scala3, Smithy, Kotlin, Elm,   
#   JSON Schema, Ruby, Dart, Python, Pike, Haskell, TypeScript Zod, TypeScript    
#   Effect Schema, PHP.                                                           
# 
# Options
# 
#  -o, --out FILE                                              The output file. Determines --lang and --top-level.        
#  -t, --top-level NAME                                        The name for the top level type.                           
#  -l, --lang LANG                                             The target language.                                       
#  -s, --src-lang SRC_LANG                                     The source language (default is json).                     
#  --src FILE|URL|DIRECTORY                                    The file, url, or data directory to type.                  
#  --src-urls FILE                                             Tracery grammar describing URLs to crawl.                  
#  --no-maps                                                   Don't infer maps, always use classes.                      
#  --no-enums                                                  Don't infer enums, always use strings.                     
#  --no-uuids                                                  Don't convert UUIDs to UUID objects.                       
#  --no-date-times                                             Don't infer dates or times.                                
#  --no-integer-strings                                        Don't convert stringified integers to integers.            
#  --no-boolean-strings                                        Don't convert stringified booleans to booleans.            
#  --no-combine-classes                                        Don't combine similar classes.                             
#  --no-ignore-json-refs                                       Treat $ref as a reference in JSON.                         
#  --graphql-schema FILE                                       GraphQL introspection file.                                
#  --graphql-introspect URL                                    Introspect GraphQL schema from a server.                   
#  --http-method METHOD                                        HTTP method to use for the GraphQL introspection query.    
#  --http-header HEADER                                        Header(s) to attach to all HTTP requests, including the    
#                                                              GraphQL introspection query.                               
#  -S, --additional-schema FILE                                Register the $id's of additional JSON Schema files.        
#  --alphabetize-properties                                    Alphabetize order of class properties.                     
#  --all-properties-optional                                   Make all class properties optional.                        
#  --quiet                                                     Don't show issues in the generated code.                   
#  --debug OPTIONS or all                                      Comma separated debug options: print-graph, print-         

#Options for C#
#
# --framework NewtonSoft|SystemTextJson                       Serialization framework                                    
# --namespace NAME                                            Generated namespace                                        
# --csharp-version 5|6                                        C# version                                                 
# --density normal|dense                                      Property density                                           
# --array-type array|list                                     Use T[] or List<T>                                         
# --number-type double|decimal                                Type to use for numbers                                    
# --any-type object|dynamic                                   Type to use for "any"                                      
# --[no-]virtual                                              Generate virtual properties (off by default)               
# --features complete|attributes-only|just-types-and-         Output features                                            
# namespace|just-types                                                                                                   
# --base-class EntityData|Object                              Base class                                                 
# --[no-]check-required                                       Fail if required properties are missing (off by default)   


