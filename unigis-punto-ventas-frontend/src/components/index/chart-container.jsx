import { useEffect, useState } from 'react';
import { getItems } from '../../services/api-service';
import { PieChart, Pie, Tooltip, Cell, ResponsiveContainer, Legend } from 'recharts';
import { formatCurrency } from '../../helpers/format-currency';

const COLORS = ['#0088FE', '#00C49F', '#FFBB28', '#FF8042', '#A28CF6'];

const ChartContainer = () => {
    const [ventasDetalle, setChart] = useState([]);


    const getDetalleVentas = async () => {
        const response = await getItems('puntoventas/getventasporzona');
        setChart(response.data.detalle);
    }


    useEffect(() => {
        getDetalleVentas();
    }, []);



    

    const total = (data) => {
        if (!Array.isArray(data)) return 0;
        return data.reduce((acc, curr) => acc + (curr.value || 0), 0);
    };


    return (
        <div>
            <h3>Total de ventas: {formatCurrency(total(ventasDetalle))}</h3>
            <ResponsiveContainer width="100%" height={400} minWidth={200}>
                <PieChart  width={700} height={700}>
                    <Pie
                        data={ventasDetalle}
                        dataKey="value"
                        nameKey="name"
                        cx="50%"
                        cy="50%"
                        outerRadius={120}
                        fill="#8884d8"
                        label={({ name, value }) => `${formatCurrency(value)}`}>
                        {ventasDetalle.map((entry, index) => (
                            <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                        ))}
                    </Pie>
                    <Tooltip formatter={(value) => formatCurrency(value) } />
                    <Legend />
                </PieChart>
            </ResponsiveContainer>
        </div>
    )
}

export default ChartContainer;