"use client";
import { useEffect, useState } from "react";
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "./ui/form";
import { z } from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Input } from "./ui/input";
import { Button } from "./ui/button";
import { getAll } from "@/app/api/Get";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "./ui/select";
import { useRouter } from "next/navigation";
import { useToast } from "@/hooks/use-toast";
import { Role } from "@/app/types/Role";

function AddEmployeeForm({
  employeeId,
  onFormSubmit,
}: {
  employeeId?: string;
  onFormSubmit?: () => void;
}) {
  const [roles, setRoles] = useState<Role[]>([]);

  const { toast } = useToast();
  const router = useRouter();

  const employeeSchema = z.object({
    firstName: z
      .string()
      .nonempty({ message: "Please enter a first name" })
      .min(2)
      .max(30),
    lastName: z
      .string()
      .nonempty({ message: "Please enter a last name" })
      .min(2)
      .max(30),
    roleId: z.string().nonempty({ message: "Please select a contact" }),
  });

  const form = useForm<z.infer<typeof employeeSchema>>({
    resolver: zodResolver(employeeSchema),
    defaultValues: {
      firstName: "",
      lastName: "",
      roleId: "",
    },
  });

  function onSubmit(values: z.infer<typeof employeeSchema>) {
    const url = employeeId
      ? `https://localhost:7036/api/employees/${employeeId}`
      : "https://localhost:7036/api/employees";
    const method = employeeId ? "PUT" : "POST";

    fetch(url, {
      method: method,
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        ...values,
      }),
    })
      .then((response) => {
        if (response.ok) {
          toast({
            title: "Success!",
            variant: "success",
            description: `Employee ${
              employeeId ? "updated" : "created"
            } successfully`,
          });
          if (onFormSubmit) {
            onFormSubmit();
          }
        } else {
          toast({
            title: "Error!",
            description: `Failed to ${
              employeeId ? "update" : "create"
            } employee`,
            variant: "destructive",
          });
          console.error(
            `Failed to ${employeeId ? "update" : "create"} employee`
          );
        }
      })
      .catch((error) =>
        console.error(
          `Error ${employeeId ? "updating" : "creating"} employee:`,
          error
        )
      );
  }

  useEffect(() => {
    getAll("employeeroles", setRoles);
  }, []);

  return (
    <Form {...form}>
      <form
        onSubmit={(e) => {
          e.preventDefault();
          e.stopPropagation();
          form.handleSubmit(onSubmit)(e);
        }}
        className="flex flex-col gap-4"
      >
        <FormField
          control={form.control}
          name="firstName"
          render={({ field }) => (
            <FormItem>
              <FormLabel>First name:</FormLabel>
              <FormControl>
                <Input placeholder="arne?" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="lastName"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Last name:</FormLabel>
              <FormControl>
                <Input placeholder="Weise?" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="roleId"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Employee Role:</FormLabel>
              <Select onValueChange={field.onChange} value={field.value}>
                <FormControl>
                  <SelectTrigger>
                    <SelectValue placeholder="Select a role" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {roles.map((role) => (
                    <SelectItem key={role.id} value={role.id.toString()}>
                      {role.role}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <FormDescription>
                Select what type of role the employee has.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button type="submit" className="md:w-fit">
          Submit
        </Button>
      </form>
    </Form>
  );
}
export default AddEmployeeForm;
