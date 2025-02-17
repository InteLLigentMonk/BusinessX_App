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
import { Contact } from "@/app/types/Contact";
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
import { Customer } from "@/app/types/Customer";

function AddCustomerForm({
  customerSlug,
  onFormSubmit,
}: {
  customerSlug?: string;
  onFormSubmit?: () => void;
}) {
  const [contacts, setContacts] = useState<Contact[]>([]);
  const [customer, setCustomer] = useState<String[]>([]);

  const { toast } = useToast();
  const router = useRouter();

  const customerSchema = z.object({
    contactId: z.string().nonempty({ message: "Please select a contact" }),
    name: z
      .string()
      .min(2)
      .max(30)
      .nonempty()
      .refine(
        (name) => {
          return !customer.includes(name);
        },
        {
          message: "Customer name must be unique",
        }
      ),
  });

  const form = useForm<z.infer<typeof customerSchema>>({
    resolver: zodResolver(customerSchema),
    defaultValues: {
      name: "",
      contactId: "",
    },
  });

  function onSubmit(values: z.infer<typeof customerSchema>) {
    const url = customerSlug
      ? `https://localhost:7036/api/customers/${customerSlug}`
      : "https://localhost:7036/api/customers";
    const method = customerSlug ? "PUT" : "POST";

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
            description: `Customer ${
              customerSlug ? "updated" : "created"
            } successfully`,
          });
          if (onFormSubmit) {
            onFormSubmit();
          }
        } else {
          toast({
            title: "Error!",
            description: `Failed to ${
              customerSlug ? "update" : "create"
            } customer`,
            variant: "destructive",
          });
          console.error(
            `Failed to ${customerSlug ? "update" : "create"} customer`
          );
        }
      })
      .catch((error) =>
        console.error(
          `Error ${customerSlug ? "updating" : "creating"} customer:`,
          error
        )
      );
  }

  useEffect(() => {
    getAll("contacts", setContacts);
    getAll("customers", (customers) => {
      setCustomer(customers.map((customer: Customer) => customer.name));
    });
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
          name="name"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Customer Name:</FormLabel>
              <FormControl>
                <Input placeholder="spaceX?" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="contactId"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Customer Contact:</FormLabel>
              <Select onValueChange={field.onChange} value={field.value}>
                <FormControl>
                  <SelectTrigger>
                    <SelectValue placeholder="Select Contact" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {contacts.map((contact) => (
                    <SelectItem key={contact.id} value={contact.id.toString()}>
                      {contact.firstName} {contact.lastName}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <FormDescription>
                Select the Current Status of the project.
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
export default AddCustomerForm;
