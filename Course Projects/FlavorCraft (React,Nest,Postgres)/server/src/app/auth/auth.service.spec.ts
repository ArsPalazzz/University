// describe('User Registration', () => {
//   it('should register a new user with valid data', async () => {
//     const registrationDto = {
//       username: 'testuser',
//       password: 'password123',
//       email: 'test@example.com',
//     };

//     const createUserMock = jest.fn().mockResolvedValue({
//       id: '1',
//       username: 'testuser',
//       email: 'test@example.com',
//     });

//     // Assuming there's a UserService with a register method
//     const userService = { register: createUserMock };

//     const result = await userService.register(registrationDto);

//     expect(result).toEqual({
//       id: '1',
//       username: 'testuser',
//       email: 'test@example.com',
//     });
//     expect(createUserMock).toHaveBeenCalledWith(registrationDto);
//   });

//   it('should fail when email is already taken', async () => {
//     const registrationDto = {
//       username: 'testuser',
//       password: 'password123',
//       email: 'test@example.com',
//     };

//     const createUserMock = jest
//       .fn()
//       .mockRejectedValue(new Error('Email already taken'));

//     const userService = { register: createUserMock };

//     try {
//       await userService.register(registrationDto);
//     } catch (error) {
//       expect(error.message).toBe('Email already taken');
//     }
//   });
// });
