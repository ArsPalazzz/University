import { AuthRole } from '@common/constants/auth.const';

export interface UserAuthPayload {
  id: string;
  role: AuthRole;
}

export interface AddUserToBannedInput {
  user_id: string;
  reason: string;
}
