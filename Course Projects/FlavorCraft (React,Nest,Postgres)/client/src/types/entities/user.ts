import { AuthRole } from "consts/entities/user.const";

export interface User {
  id: string;
  username: string;
  email: string;
  avatar_url: string;
  role: AuthRole;
  created_at: Date;
  is_blocked: boolean;
}

export interface UserProfile extends User {
  followers_count: number;
  following_count: number;
  isFollowingAuthor?: boolean | undefined;
}

export interface UserAuthPayload {
  id: string;
  role: AuthRole;
}
