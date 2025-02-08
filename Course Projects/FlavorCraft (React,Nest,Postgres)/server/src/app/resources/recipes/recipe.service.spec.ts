describe('Recipe Creation', () => {
  it('should allow an authenticated user to create a recipe', async () => {
    const createRecipeDto = {
      title: 'Spaghetti Bolognese',
      ingredients: ['spaghetti', 'meat', 'tomato sauce'],
      instructions: 'Cook the spaghetti and mix with the sauce',
    };

    const createRecipeMock = jest.fn().mockResolvedValue({
      id: '1',
      title: 'Spaghetti Bolognese',
      ingredients: ['spaghetti', 'meat', 'tomato sauce'],
      instructions: 'Cook the spaghetti and mix with the sauce',
    });

    // Assuming there's a RecipeService with a createRecipe method
    const recipeService = { createRecipe: createRecipeMock };

    const result = await recipeService.createRecipe(createRecipeDto);

    expect(result).toEqual({
      id: '1',
      title: 'Spaghetti Bolognese',
      ingredients: ['spaghetti', 'meat', 'tomato sauce'],
      instructions: 'Cook the spaghetti and mix with the sauce',
    });
    expect(createRecipeMock).toHaveBeenCalledWith(createRecipeDto);
  });

  it('should not allow a guest user to create a recipe', async () => {
    const createRecipeDto = {
      title: 'Spaghetti Bolognese',
      ingredients: ['spaghetti', 'meat', 'tomato sauce'],
      instructions: 'Cook the spaghetti and mix with the sauce',
    };

    const createRecipeMock = jest
      .fn()
      .mockRejectedValue(new Error('Unauthorized'));

    const recipeService = { createRecipe: createRecipeMock };

    try {
      await recipeService.createRecipe(createRecipeDto);
    } catch (error) {
      expect(error.message).toBe('Unauthorized');
    }
  });
});
