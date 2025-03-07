import { PrismaClient } from "@prisma/client";

const prisma = new PrismaClient();

class TurtleService {
  async getAllTurtles() {
    try {
      const turtles = await prisma.turtles.findMany();
      return turtles;
    } catch (error) {
      throw new Error("Unable to fetch turtles");
    }
  }

  async getTurtlesById(id) {
    if (isNaN(id)) {
      throw new Error("Id is not a number");
    }
    try {
      const turtle = await prisma.turtles.findUnique({
        where: { id: parseInt(id) },
      });
      if (!turtle) {
        throw new Error("Turtle with this Id is not found");
      }
      return turtle;
    } catch (error) {
      throw new Error("Unable to find turtles");
    }
  }

  async getTurtlesByFavouritePizza(pizzaName) {
    try {
      const pizza = await prisma.pizzas.findUnique({
        where: { name: pizzaName },
      });

      if (!pizza) {
        throw Error("Pizza not found");
      }

      const turtles = await prisma.turtles.findMany({
        where: { favoritePizzaId: pizza.id },
      });

      if (!turtles || turtles.length === 0) {
        throw new Error("Turtle with this favourite pizza not found");
      }

      return turtles;
    } catch (error) {
      console.error(error.stack);
      throw new Error("Unable to find turtles");
    }
  }

  async postNewTurtle(data) {
    console.log(data);
    try {
      if (!data.name || !data.color) {
        throw new Error("Name and color are required fields");
      }
      let weapon = await prisma.weapons.findUnique({
        where: { id: data?.weaponId },
      });
      if (data.weaponId && !weapon) {
        throw new Error("Weapon with this id not found");
      }

      if (data.favoritePizzaId) {
        const pizza = await prisma.pizzas.findUnique({
          where: { id: data.favoritePizzaId },
        });
        if (!pizza) {
          throw new Error("Favorite pizza with this id not found");
        }
      }

      const newTurtle = await prisma.turtles.create({
        data: {
          name: data.name,
          color: data.color,
          Weapons: { connect: { id: data.weaponId } },
          Pizzas_Turtles_favoritePizzaIdToPizzas: {
            connect: { id: data.favoritePizzaId },
          },
          Pizzas_Turtles_secondFavoritePizzaIdToPizzas: {
            connect: { id: data.secondFavoritePizzaId },
          },
          image: data.image,
        },
      });

      console.log(newTurtle);
      return newTurtle;
    } catch (error) {
      throw new Error("Unable to create new turtle: " + error.message);
    }
  }

  async updateTurtleById(id, newData) {
    try {
      if (isNaN(id)) {
        throw new Error("Id is not a number");
      }

      const isUsedTurtleName = await prisma.turtles.findUnique({
        where: { name: newData.name },
      });

      if (isUsedTurtleName)
        throw new Error("Turtle with this name already exist");

      const existingTurtle = await prisma.turtles.findUnique({
        where: { id: parseInt(id) },
      });

      if (!existingTurtle) {
        throw new Error("Turtle with this id not found");
      }

      console.log(newData, existingTurtle);
      const updatedTurtle = await prisma.turtles.update({
        where: { id: parseInt(id) },
        data: {
          name: newData?.name || existingTurtle.name,
          color: newData?.color || existingTurtle.color,
          weapon: newData?.weaponId
            ? { connect: { id: newData.weaponId } }
            : undefined,
          favoritePizza: newData.favoritePizzaId
            ? { connect: { id: newData.favoritePizzaId } }
            : undefined,
          secondFavoritePizza: newData.secondFavoritePizzaId
            ? { connect: { id: newData.secondFavoritePizzaId } }
            : undefined,
        },
      });
      return updatedTurtle;
    } catch (error) {
      throw new Error("Unable to update turtle: " + error.message);
    }
  }

  async deleteTurtleById(id) {
    try {
      if (isNaN(id)) {
        throw new Error("Id is not a number");
      }
      const existingTurtle = await prisma.turtles.findUnique({
        where: { id: parseInt(id) },
      });
      if (!existingTurtle) {
        throw new Error("Turtle with this id not found");
      }
      await prisma.turtles.delete({
        where: { id: parseInt(id) },
      });
      return existingTurtle;
    } catch (error) {
      throw new Error("Unable to delete turtle: " + error.message);
    }
  }

  async bindFavoritePizzaTurtle(turtleId, pizzaId) {
    try {
      console.log(turtleId, pizzaId);
      if (isNaN(turtleId)) {
        throw new Error("Id is not a number");
      }

      const turtle = await prisma.turtles.findUnique({
        where: { id: parseInt(turtleId) },
      });

      console.log(turtle);

      if (!turtle) {
        throw new Error("Turtle with this id not found");
      }

      if (!pizzaId) throw new Error("Pizza id is required");

      const pizza = await prisma.pizzas.findUnique({
        where: { id: pizzaId },
      });

      if (!pizza) {
        throw new Error("Pizza with this id not found");
      }

      turtle.favoritePizzaId = pizzaId;
      await prisma.turtles.update({
        where: { id: parseInt(turtleId) },
        data: {
          favoritePizza: { connect: { id: pizzaId } },
        },
      });

      return turtle;
    } catch (error) {
      throw new Error("Unable to update turtle: " + error.message);
    }
  }

  async bindSecondFavoritePizzaTurtle(turtleId, pizzaId) {
    try {
      if (isNaN(turtleId)) {
        throw new Error("Id is not a number");
      }

      const turtle = await prisma.turtles.findUnique({
        where: { id: parseInt(turtleId) },
      });

      if (!turtle) {
        throw new Error("Turtle with this id not found");
      }

      turtle.secondFavoritePizzaId = pizzaId;
      await prisma.turtles.update({
        where: { id: parseInt(turtleId) },
        data: {
          secondFavoritePizza: { connect: { id: pizzaId } },
        },
      });

      return turtle;
    } catch (error) {
      throw new Error("Unable to update turtle: " + error.message);
    }
  }

  async bindWeaponTurtle(turtleId, weaponId) {
    try {
      if (isNaN(turtleId)) {
        throw new Error("Id is not a number");
      }

      const turtle = await prisma.turtles.findUnique({
        where: { id: parseInt(turtleId) },
      });

      if (!turtle) {
        throw new Error("Turtle with this id not found");
      }

      turtle.weaponId = weaponId;
      await prisma.turtles.update({
        where: { id: parseInt(turtleId) },
        data: {
          weapon: { connect: { id: weaponId } },
        },
      });

      return turtle;
    } catch (error) {
      throw new Error("Unable to update turtle: " + error.message);
    }
  }

  async unbindWeaponTurtle(turtleId) {
    try {
      if (isNaN(turtleId)) {
        throw new Error("Id is not a number");
      }

      const turtle = await prisma.turtles.findUnique({
        where: { id: parseInt(turtleId) },
      });
      if (!turtle) {
        throw new Error("Turtle with this id not found");
      }

      turtle.weaponId = null;
      await prisma.turtles.update({
        where: { id: parseInt(turtleId) },
        data: {
          weaponId: null,
        },
      });

      return turtle;
    } catch (error) {
      throw new Error("Unable to update turtle: " + error.message);
    }
  }

  async unbindFavoritePizzaTurtle(turtleId) {
    try {
      if (isNaN(turtleId)) {
        throw new Error("Id is not a number");
      }

      const turtle = await prisma.turtles.findUnique({
        where: { id: parseInt(turtleId) },
      });

      if (!turtle) {
        throw new Error("Turtle with this id not found");
      }

      turtle.favoritePizzaId = null;
      await prisma.turtles.update({
        where: { id: parseInt(turtleId) },
        data: {
          favoritePizzaId: null,
        },
      });

      return turtle;
    } catch (error) {
      throw new Error("Unable to update turtle: " + error.message);
    }
  }

  async unbindSecondFavoritePizzaTurtle(turtleId) {
    try {
      if (isNaN(turtleId)) {
        throw new Error("Id is not a number");
      }

      const turtle = await prisma.turtles.findUnique({
        where: { id: parseInt(turtleId) },
      });

      if (!turtle) {
        throw new Error("Turtle with this id not found");
      }

      turtle.secondFavoritePizzaId = null;
      await prisma.turtles.update({
        where: { id: parseInt(turtleId) },
        data: {
          secondFavoritePizzaId: null,
        },
      });

      return turtle;
    } catch (error) {
      throw new Error("Unable to update turtle: " + error.message);
    }
  }
}

export default new TurtleService();
