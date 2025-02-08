import { Test, TestingModule } from '@nestjs/testing';
import { FollowService } from './follow.service';
import { PrismaService } from '@database/prisma.service';
import { BadRequestException } from '@nestjs/common';

describe('FollowService', () => {
  let followService: FollowService;
  let prismaService: {
    followings: {
      findMany: jest.Mock;
      findUnique: jest.Mock;
      count: jest.Mock;
      create: jest.Mock;
      delete: jest.Mock;
      findFirst: jest.Mock;
    };
  };

  beforeEach(async () => {
    // Mock PrismaService
    prismaService = {
      followings: {
        findMany: jest.fn(),
        findUnique: jest.fn(),
        count: jest.fn(),
        create: jest.fn(),
        delete: jest.fn(),
        findFirst: jest.fn(),
      },
    };

    const module: TestingModule = await Test.createTestingModule({
      providers: [
        FollowService,
        { provide: PrismaService, useValue: prismaService },
      ],
    }).compile();

    followService = module.get<FollowService>(FollowService);
  });

  describe('createFollow', () => {
    it('should create a follow if it does not already exist', async () => {
      prismaService.followings.count.mockResolvedValue(0);
      prismaService.followings.create.mockResolvedValue({
        id: 1,
        follower_id: 'user1',
        followed_id: 'user2',
      });

      const result = await followService.createFollow({
        user_id: 'user1',
        followed_id: 'user2',
      });

      expect(result).toEqual({
        id: 1,
        follower_id: 'user1',
        followed_id: 'user2',
      });
      expect(prismaService.followings.count).toHaveBeenCalledWith({
        where: { follower_id: 'user1', followed_id: 'user2' },
      });
      expect(prismaService.followings.create).toHaveBeenCalledWith({
        data: { follower_id: 'user1', followed_id: 'user2' },
      });
    });

    it('should throw an error if user tries to follow themselves', async () => {
      await expect(
        followService.createFollow({
          user_id: 'user1',
          followed_id: 'user1',
        }),
      ).rejects.toThrow(BadRequestException);
      await expect(
        followService.createFollow({
          user_id: 'user1',
          followed_id: 'user1',
        }),
      ).rejects.toThrow('You cannot follow yourself');
    });

    it('should throw an error if the user is already following', async () => {
      prismaService.followings.count.mockResolvedValue(1);

      await expect(
        followService.createFollow({
          user_id: 'user1',
          followed_id: 'user2',
        }),
      ).rejects.toThrow(BadRequestException);
      await expect(
        followService.createFollow({
          user_id: 'user1',
          followed_id: 'user2',
        }),
      ).rejects.toThrow('You have already followed this user');
    });
  });

  describe('deleteFollow', () => {
    it('should delete a follow if it exists', async () => {
      prismaService.followings.findFirst.mockResolvedValue({
        id: 1,
        follower_id: 'user1',
        followed_id: 'user2',
      });
      prismaService.followings.delete.mockResolvedValue({
        id: 1,
        follower_id: 'user1',
        followed_id: 'user2',
      });

      const result = await followService.deleteFollow({
        follower_id: 'user1',
        followed_id: 'user2',
      });

      expect(result).toEqual({
        id: 1,
        follower_id: 'user1',
        followed_id: 'user2',
      });
      expect(prismaService.followings.findFirst).toHaveBeenCalledWith({
        where: { followed_id: 'user2', follower_id: 'user1' },
      });
      expect(prismaService.followings.delete).toHaveBeenCalledWith({
        where: { id: 1 },
      });
    });

    it('should throw an error if user tries to unfollow themselves', async () => {
      await expect(
        followService.deleteFollow({
          follower_id: 'user1',
          followed_id: 'user1',
        }),
      ).rejects.toThrow(BadRequestException);
      await expect(
        followService.deleteFollow({
          follower_id: 'user1',
          followed_id: 'user1',
        }),
      ).rejects.toThrow('You cannot unfollow yourself');
    });

    it('should throw an error if the follow does not exist', async () => {
      prismaService.followings.findFirst.mockResolvedValue(null);

      await expect(
        followService.deleteFollow({
          follower_id: 'user1',
          followed_id: 'user2',
        }),
      ).rejects.toThrow(BadRequestException);
      await expect(
        followService.deleteFollow({
          follower_id: 'user1',
          followed_id: 'user2',
        }),
      ).rejects.toThrow("You haven't followed this user");
    });
  });

  describe('findAllFollowers', () => {
    it('should return all followers of a user', async () => {
      const followersMock = [
        { id: 1, follower_id: 'user1', followed_id: 'user2' },
        { id: 2, follower_id: 'user3', followed_id: 'user2' },
      ];

      prismaService.followings.findMany.mockResolvedValue(followersMock);

      const result = await followService.findAllFollowers('user2');

      expect(result).toEqual(followersMock);
      expect(prismaService.followings.findMany).toHaveBeenCalledWith({
        where: { follower_id: 'user2' },
      });
    });
  });

  describe('findAllFollowings', () => {
    it('should return all followings of a user', async () => {
      const followingsMock = [
        { id: 1, follower_id: 'user2', followed_id: 'user1' },
        { id: 2, follower_id: 'user2', followed_id: 'user3' },
      ];

      prismaService.followings.findMany.mockResolvedValue(followingsMock);

      const result = await followService.findAllFollowings('user2');

      expect(result).toEqual(followingsMock);
      expect(prismaService.followings.findMany).toHaveBeenCalledWith({
        where: { followed_id: 'user2' },
      });
    });
  });
});
