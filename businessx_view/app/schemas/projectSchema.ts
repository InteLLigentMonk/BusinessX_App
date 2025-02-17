import { z } from "zod";

export const projectSchema = z.object({
  name: z
    .string()
    .nonempty({ message: "Project Name can't be empty." })
    .min(3, { message: "Must be atleast 3 characters long" })
    .max(30, { message: "Must be atmost 30 characters long" }),
  description: z
    .string()
    .max(400, { message: "Must be atmost 400 characters long" }),
  startDate: z.date(),
  endDate: z.date(),
  statusId: z.string().nonempty({ message: "Status can't be empty." }),
  customerId: z.string().nonempty({ message: "Customer can't be empty." }),
  contactId: z.string(),
  serviceId: z.string().nonempty({ message: "Service can't be empty." }),
  employeeId: z.string().nonempty({ message: "Employee can't be empty." }),
});
