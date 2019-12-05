using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using SOFD.File;
using SOFD.Component;

namespace MainLibrary
{
    public class CRecipe
    {
        public string RecipeID = "";
        public DateTime CreateTime = DateTime.Now;
        public string Desc = "";
        public string Creator = "";
        public Dictionary<string, CRecipe> SubRecipes = new Dictionary<string, CRecipe>();

        public int SubRecipeCount
        {
            get
            {
                return SubRecipes.Count;
            }
        }

        public CRecipe()
        {

        }

        public void AddSubRecipe(CRecipe subRecipe)
        {
            if (!SubRecipes.ContainsKey(subRecipe.RecipeID))
            {
                SubRecipes.Add(subRecipe.RecipeID, subRecipe);
            }
            else
            {
                SubRecipes[subRecipe.RecipeID] = subRecipe;
            }
        }

        public static CRecipe Parser(string recipeInfos)
        {
            CRecipe recipe = new CRecipe();

            string[] splited = recipeInfos.Split(',');
            recipe.RecipeID = splited[0];
            recipe.Creator = splited[2];
            recipe.CreateTime = DateTime.Parse(splited[3]);
            recipe.Desc = splited[4];
            return recipe;
        }
    }

    public class CRecipeManager : ACustomPropertyContainer
    {
        private static CRecipeManager _inst = new CRecipeManager();
        public static CRecipeManager Inst
        {
            get
            {
                if (_inst != null)
                    _inst = new CRecipeManager();
                return _inst;
            }
        }
        public void Init()
        {
            string recipeCount = this.GetCustomProperty("RECIPE_MANAGER", "RECIPES_COUNT", "0", "등록 RECIPE 수 정보");
            
            for (int i = 0; i < int.Parse(recipeCount); i++)
			{
                string recipeInfos = this.GetCustomProperty("RECIPE_MANAGER", "RECIPE_" + i.ToString("0000"), "", "PPID RECIPEID yyyyMMddHHmmss DESC CREATOR,PPID RECIPEID yyyyMMddHHmmss DESC CREATOR...등록 RECIPE 정보");
                CRecipe recipe = CRecipe.Parser(recipeInfos);
			}
            
        }

        public object _recipesLock = new object();
        public Dictionary<string, string> Recipes = new Dictionary<string, string>();

        public bool Contains(string recipeIdorPPID)
        {
            return Recipes.ContainsKey(recipeIdorPPID);
        }

        public string GetRecipeNo(string recipeIdorPPID)
        {
            lock (_recipesLock)
            {
                if (Recipes.ContainsKey(recipeIdorPPID))
                {
                    return Recipes[recipeIdorPPID];
                }
                return "";
            }
        }

        public bool CreateRecipe(string recipeIdorPPID, string subRecipeId)
        {
            lock (_recipesLock)
            {
                if (Recipes.ContainsKey(recipeIdorPPID))
                {
                    return false;
                }

                Recipes.Add(recipeIdorPPID, subRecipeId);
                return true;
            }
        }

        public bool ModifyRecipe(string recipeIdorPPID, string subRecipeId)
        {
            lock (_recipesLock)
            {
                if (!Recipes.ContainsKey(recipeIdorPPID))
                {
                    return false;
                }

                Recipes[recipeIdorPPID] = subRecipeId;
                return true;
            }
        }

        public bool DeleteRecipe(string recipeIdorPPID)
        {
            lock (_recipesLock)
            {
                if (Recipes.ContainsKey(recipeIdorPPID))
                {
                    return false;
                }

                Recipes.Remove(recipeIdorPPID);

                return true;
            }
        }
    }

}
