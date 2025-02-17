import AddCustomerForm from "@/components/AddCustomerForm";
import AddServiceForm from "@/components/AddServiceForm";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

function AddCustomer() {
  return (
    <Card className="w-full max-w-[960px] overflow-hidden">
      <CardHeader className="bg-secondary">
        <CardTitle>Add New Customer</CardTitle>
        <CardDescription>What customer would you like to add?</CardDescription>
      </CardHeader>
      <CardContent className="pt-4">
        <AddCustomerForm />
      </CardContent>
    </Card>
  );
}
export default AddCustomer;
