// import { Test, TestingModule } from '@nestjs/testing';
// import { UserService } from './user.service';
// import { PrismaService } from './../../database/prisma.service';
// import { BaseFilterService } from './../../common/filters/base-filter.service';
// import { FilterUsersDto } from './dto/filter-users.dto';

// // Моки для зависимостей
// const prismaMock = {
//   users: {
//     findUnique: jest.fn(),
//   },
// };

// const baseFilterServiceMock = {
//   filter: jest.fn(),
// };

// describe('UserService', () => {
//   let userService: UserService;
//   let prismaService: PrismaService;
//   let baseFilterService: BaseFilterService;

//   beforeEach(async () => {
//     const module: TestingModule = await Test.createTestingModule({
//       providers: [
//         UserService,
//         { provide: PrismaService, useValue: prismaMock },
//         { provide: BaseFilterService, useValue: baseFilterServiceMock },
//       ],
//     }).compile();

//     userService = module.get<UserService>(UserService);
//     prismaService = module.get<PrismaService>(PrismaService);
//     baseFilterService = module.get<BaseFilterService>(BaseFilterService);
//   });

//   it('should be defined', () => {
//     expect(userService).toBeDefined();
//   });

//   describe('filterAll', () => {
//     it('should call baseFilterService.filter with correct parameters', async () => {
//       const filterDto = {
//         search: 'john',
//         role: 'admin',
//         sortBy: 'username',
//         order: 'asc',
//       } as FilterUsersDto;

//       const mockResponse = [{ id: '1', username: 'john_doe', role: 'admin' }];

//       baseFilterServiceMock.filter.mockResolvedValue(mockResponse);

//       const result = await userService.filterAll(filterDto);

//       expect(result).toEqual(mockResponse);
//       expect(baseFilterService.filter).toHaveBeenCalledWith('users', {
//         search: 'john',
//         searchColumn: 'username',
//         sortBy: 'username',
//         order: 'asc',
//         filters: { role: 'admin' },
//       });
//     });
//   });

//   describe('findOneById', () => {
//     it('should return a user by ID', async () => {
//       const mockUser = { id: '1', username: 'john_doe', role: 'admin' };
//       prismaMock.users.findUnique.mockResolvedValue(mockUser);

//       const result = await userService.findOneById('1');

//       expect(result).toEqual(mockUser);
//       expect(prismaMock.users.findUnique).toHaveBeenCalledWith({
//         where: { id: '1' },
//       });
//     });

//     it('should return null if user not found', async () => {
//       prismaMock.users.findUnique.mockResolvedValue(null);

//       const result = await userService.findOneById('non-existent-id');

//       expect(result).toBeNull();
//       expect(prismaMock.users.findUnique).toHaveBeenCalledWith({
//         where: { id: 'non-existent-id' },
//       });
//     });
//   });
// });
