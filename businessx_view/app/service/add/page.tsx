import AddServiceForm from "@/components/AddServiceForm";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

function AddService() {
  return (
    <Card className="w-full max-w-[960px] overflow-hidden">
      <CardHeader className="bg-secondary">
        <CardTitle>Add New Service</CardTitle>
        <CardDescription>What service would you like to add?</CardDescription>
      </CardHeader>
      <CardContent className="pt-4">
        <AddServiceForm />
      </CardContent>
    </Card>
  );
}
export default AddService;
