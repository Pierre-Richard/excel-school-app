export interface Student {
  id?: number;
  className?: string;
  userId?: number;
  classId: number;
  parentId: number;
  name: string;
  firstname: string;
  studentNumber: number;
  birthDate: Date | string;
}
