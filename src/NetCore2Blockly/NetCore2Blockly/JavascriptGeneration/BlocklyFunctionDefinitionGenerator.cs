﻿using NetCore2Blockly.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore2Blockly.JavascriptGeneration
{
    /// <summary>
    /// generates blockly functions
    /// </summary>
    public class BlocklyFunctionDefinitionGenerator
    {

        /// <summary>
        /// Generates the property definitions.
        /// </summary>
        /// <param name="actionInfo">The action information.</param>
        /// <returns></returns>
        public string GeneratePropertyDefinitions(ActionInfo actionInfo)
        {
            string tooltip = $"{actionInfo.GenerateCommandName()} :";
            var strPropsDefinition = "";

            foreach (var param in actionInfo.Params)
            {
                var blocklyType = param.Value.type.TranslateToBlocklyType();
                var typeName = param.Key;
                string blocklyTypeCheck = blocklyType;
                if (blocklyTypeCheck?.Length > 0)
                    blocklyTypeCheck = $"'{blocklyTypeCheck}'";

                if (blocklyTypeCheck == "'Array'")
                {
                    //Dictionary<string,string> is ienumerable, but an object
                    blocklyTypeCheck = "null";
                }
                
                strPropsDefinition += $@"
                    this.appendValueInput('val_{typeName}')
                    .setCheck({blocklyTypeCheck})
                    .appendField('{typeName}'); ";

                tooltip += $"{typeName}: {blocklyType}";

            }
            if(actionInfo.ReturnType.id != null)
            tooltip += $" returns: {actionInfo.ReturnType.TranslateToBlocklyType()}";
            
            return strPropsDefinition + ";" + $" this.setTooltip('{tooltip}');";
        }


        /// <summary>
        /// Generates the function definition.
        /// blockly block definition for action
        /// </summary>
        /// <param name="actionInfo">The action information.</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public string GenerateFunctionDefinition(ActionInfo actionInfo,string key)
        {
            var strPropsDefinition = GeneratePropertyDefinitions(actionInfo);
            var returnType = "";
            if (actionInfo.ReturnType.id != null)
                returnType = $@"this.setOutput(true,'{actionInfo.ReturnType.TranslateToBlocklyType()}');";
            else
                returnType = $@"this.setOutput(true,'');";
            var actionHash  = actionInfo.CustomGetHashCode();
            string[] verbHasImage =new string[] { "patch","get", "post", "put", "delete" };
            bool hasImage = verbHasImage.Contains(actionInfo.Verb.ToLower());
            var blockColor = BlocklyStringToColor.ConvertToHue(actionHash);
            string site = string.IsNullOrWhiteSpace(GenerateBlocklyFilesHostedService.InternalSiteUrl) ? "" : GenerateBlocklyFilesHostedService.InternalSiteUrl;
            return $@"
                Blockly.Blocks['{actionInfo.GenerateCommandName()}'] = {{
                          init: function() {{
                            this.setColour({blockColor});
                            this.appendDummyInput()" +

                            (hasImage?
                                $".appendField(new Blockly.FieldImage('{site}images/{actionInfo.Verb.ToLower()}.png', 90, 20, {{ alt: '{actionInfo.Verb}', flipRtl: 'FALSE' }}))"
                                :"")+
                                $".appendField('{actionInfo.CommandDisplayName(!hasImage)}');"                                
                                +Environment.NewLine
                                +$@"{strPropsDefinition}
                                {returnType}
                                }}//init
                        }};//{actionInfo.ActionName}
                        ";
        }
    }
}
